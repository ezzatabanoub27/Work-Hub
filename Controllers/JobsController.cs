using Easy_Job.Data.AppDBContext;
using Easy_Job.Data.DTOs;
using Easy_Job.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Easy_Job.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobsController : ControllerBase
    {

        private readonly EasyContext _data;
        public JobsController(EasyContext data)
        {
            _data = data;
        }




        [HttpGet("GetAllJobs")]

        public async Task<IActionResult> AllJobs()
        {
            var AllJobs = await _data.Jobs.ToListAsync();
            return Ok(AllJobs);
        }

        [HttpGet("GetByID  {id} ")]

        public async Task<IActionResult> GetById(int id)
        {
            var Job = await _data.Jobs.FindAsync(id);
            if (Job == null)
            {
                return NotFound();

            }
            return Ok(Job);
        }


        [HttpPost("AddJob")]

        public async Task<IActionResult>AddJob(JobDTO   dto)
        {
            Job newjob = new()
            {
                Title = dto.Title,
                Description = dto.Description,
                Salary = dto.Salary,
                Requirments = dto.Requirments,
                Location = dto.Location,
                Created = dto.Created,
                appuser_Id = dto.appuser_Id,
                company_Id = dto.company_Id

            };
            await _data.AddAsync(newjob);
            _data.SaveChanges();
            return Ok(newjob);
            


        }

        [HttpGet("Search")]
        public async Task<IActionResult>SearchJob(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return BadRequest("JobName is Requierd");
            }
            var jobs = await _data.Jobs.Where(u => u.Title.Contains(name,StringComparison.OrdinalIgnoreCase)).ToListAsync();

            if (!jobs.Any())
            {
                return NotFound("No Jobs Found With That Title");
            }
            return Ok(jobs);

        }


    }
}
