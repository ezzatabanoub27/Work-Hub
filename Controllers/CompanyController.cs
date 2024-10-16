using Easy_Job.Data.AppDBContext;
using Easy_Job.Data.DTOs;
using Easy_Job.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace Easy_Job.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {

        private readonly EasyContext _data;
        public CompanyController(EasyContext data)
        {
            _data = data;
        }


        [HttpGet("AllCompanies")]
        public async Task<IActionResult> AllCompanies()
        {
            var company = await _data.Companies.ToListAsync();

            return Ok(company);
        }


        [HttpPost("AddCompany")]

        public async Task<IActionResult>AddCompany([FromForm]CompanyDTO dto)
        {
            using var datastream = new MemoryStream();
            await dto.Photo.CopyToAsync(datastream);

            Company newcompany = new()
            {
                Name = dto.Name,
                Location = dto.Location,
                Description = dto.Description,
                Photo = datastream.ToString(),
                Website = dto.Website

            };
            await _data.AddAsync(newcompany);
            _data.SaveChanges();
            return Ok(newcompany);
        }


        [HttpGet("GetCompanyById{id}")]

        public async Task<IActionResult>GetById(int id)
        {
            var company = await _data.Companies.FindAsync(id);
            if (company == null)
            {
                return NotFound();
            }
            return Ok(company);
        }
    }
}
