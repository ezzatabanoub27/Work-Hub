using Easy_Job.Data.DTOs;
using Easy_Job.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Diagnostics.Eventing.Reader;
using System.IdentityModel.Tokens.Jwt;
using System.Runtime.InteropServices;
using System.Security.Claims;
using System.Text;

namespace Easy_Job.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IConfiguration configuration;

        public AccountController(UserManager<AppUser> userManager   , IConfiguration configuration)
        {
            _userManager = userManager;
            this.configuration = configuration;
        }


       // Registration Function 

        [HttpPost("Register")]
        
        public async Task<IActionResult>RegisterUser([FromBody]NewUserDTO dto)
        {
            if (ModelState.IsValid)
            {
                AppUser appuser = new()
                {
                    UserName =dto.Name,
                    Name=dto.Name,
                    Email = dto.Email,
                    Password = dto.Password,
                    UserType=dto.UserType

                };
                IdentityResult result = await _userManager.CreateAsync(appuser, dto.Password);
                if (result.Succeeded)
                {
                    return Ok("Success");
                }
                else
                {
                    foreach(var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }

            }
            return BadRequest(ModelState);


        }

       //login function 

        [HttpPost("Login")]
        public async Task <IActionResult>LoginUser([FromBody]LoginDTO logindto)
        {
            if (ModelState.IsValid)
            {
                AppUser? user = await _userManager.FindByNameAsync(logindto.username);
                if (user != null) 
                {
                    if (await _userManager.CheckPasswordAsync(user, logindto.password)) 
                    {


                        var claims = new List<Claim>();
                        claims.Add(new Claim(ClaimTypes.Name, user.Name));
                        claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id));
                        claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
                        var roles = await _userManager.GetRolesAsync(user);
                        foreach(var role in roles)
                        {
                            claims.Add(new Claim(ClaimTypes.Role, role.ToString()));
                        }

                        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:SecretKey"]));
                        var sc = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                        var token = new JwtSecurityToken(



                            claims: claims,
                            issuer: configuration["JWT:Issuer"],
                            audience: configuration["JWT:Audience"],
                            expires: DateTime.Now.AddDays(1),
                            signingCredentials: sc

                            ) ;
                        var _token = new {

                            token = new JwtSecurityTokenHandler().WriteToken(token),
                            expiration = token.ValidTo,
                        };
                    return Ok(_token);




                    }
                    else
                    {
                        return Unauthorized();
                    }
                
                }
                else
                {
                     ModelState.AddModelError("","UserName Or Password is InValid ");
                }
            }
            return BadRequest(ModelState);
        }



    }
}
