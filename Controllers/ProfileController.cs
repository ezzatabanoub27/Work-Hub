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
    public class ProfileController : ControllerBase
    {

        private readonly EasyContext _data;
        public ProfileController(EasyContext data)
        {
            _data = data;
        }

        [HttpPost("CreateProfile")]

        public async Task<IActionResult> CreateProfile([FromForm] ProfileDTO dto)
        {
            using var datastream = new MemoryStream();
            await dto.profile_Picture.CopyToAsync(datastream);
            await dto.Resume_Path.CopyToAsync(datastream);

            Profile newprofile = new()
            {
                Summery = dto.Summery,
                Resume_Path = datastream.ToString(),
                profile_Picture = datastream.ToString(),
                Skills = dto.Skills,
                Education = dto.Education,
                appuser_Id = dto.appuser_Id,
                Experiences = dto.Experiences
            };

            await _data.Profiles.AddAsync(newprofile);
            _data.SaveChanges();
            return Ok(newprofile);
        }


        [HttpGet("AllProfiles")]
        public async Task<IActionResult> AllProfiles()
        {
            var allprofiles = await _data.Profiles.ToListAsync();
            return Ok(allprofiles);
        }


        [HttpGet("GetProfileById{id}")]

        public async Task<IActionResult> GetById(int id)
        {
            

            var profile = await _data.Profiles.FindAsync(id);
            if (profile == null)
            {
                return NotFound();
            }
            return Ok(profile);
        }

        [HttpPut ("{id}")]

        public async Task<IActionResult>UpdateProfile(int id , ProfileDTO dto)
        {

            using var datastream = new MemoryStream();
            await dto.Resume_Path.CopyToAsync(datastream);
            await dto.profile_Picture.CopyToAsync(datastream);

            var update = await _data.Profiles.FindAsync(id);
            if (update == null)
            {
                return NotFound("No User With Id +" + "{id}");
                    
            }
            update.Education = dto.Education;
            update.appuser_Id = dto.appuser_Id;
            update.Experiences = dto.Experiences;
            update.profile_Picture = datastream.ToString();
            update.Resume_Path = datastream.ToString();
            update.Summery = dto.Summery;
            update.Skills = dto.Skills;

            _data.SaveChanges();
            return Ok(update);

        }

        [HttpDelete]

        public async Task<IActionResult>DeleteProfile(int id)
        {
            var dprofile = await _data.Profiles.FindAsync(id);
            if (dprofile == null)
            {
                return NotFound();

            }
            _data.Profiles.Remove(dprofile);
            _data.SaveChanges();
            return Ok(dprofile);
        }
    }
}
