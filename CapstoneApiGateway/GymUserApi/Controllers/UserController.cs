using GymUserApi.Model;
using GymUserApi.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace GymUserApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly ITokenGeneratorService _service;

        public UserController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration, ITokenGeneratorService service)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _service = service;
        }
        [HttpPost("register")]
        public async Task<IActionResult> CreateUser(User user)
        {
            var u = new IdentityUser()
            {
                Email = user.Email,
                UserName = user.UserName,
                PhoneNumber = user.ContactNo
            };
            var result = await _userManager.CreateAsync(u, user.Password);
            if (result.Succeeded)
            {
                if (user.Role.Equals("Admin"))
                {
                    await _roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                    await _userManager.AddToRoleAsync(u, UserRoles.Admin);
                }
                else if (user.Role.Equals("Employee"))
                {
                    await _roleManager.CreateAsync(new IdentityRole(UserRoles.Employee));
                    await _userManager.AddToRoleAsync(u, UserRoles.Employee);
                }
                else
                {
                    await _roleManager.CreateAsync(new IdentityRole(UserRoles.Member));
                    await _userManager.AddToRoleAsync(u, UserRoles.Member);
                }
                return Ok("true");
            }
            else
            {
                return Conflict(JsonConvert.SerializeObject(result.Errors.ToString()));
            }

        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(User user)
        {
            var result = await _signInManager.PasswordSignInAsync(user.UserName, user.Password, false, false);
            if (result.Succeeded)
            {
                var user_res = await _userManager.FindByNameAsync(user.UserName);
                var userRoles = await _userManager.GetRolesAsync(user_res);
                var authClaims = new []
                {
                    new Claim("Name", user.UserName),
                    new Claim("role", userRoles[0]),
                };
                return Ok(_service.GenerateToken(authClaims));
            }
            else
            {
                return StatusCode(500, "Invalid username or password");
            }
            
        }
        [HttpGet("logout")]
        public async Task<IActionResult> logout()
        {
            await _signInManager.SignOutAsync();
            return Ok("Signout Successfully");
        }
        [HttpGet("profile/{Email}")]
        public async Task<IActionResult> getProfileByEmail(string Email)
        {
            var profile = await _userManager.FindByEmailAsync(Email);
            if (profile != null)
            {
                return Ok(JsonConvert.SerializeObject(profile));
            }
            else
            {
                return NotFound("Profile Not Found");
            }
        }
        //[HttpPost]
        //public async Task<IActionResult> IsExists() { }
        //[HttpPut("update/{userName}")]
        //public async Task<IActionResult> Update(string userName, User user)
        //{
        //    var res = _userManager.FindByIdAsync(userName);
        //    var temp = res.Result;
        //    temp.Email = user.Email;
        //    await _userManager.UpdateAsync(temp);
        //    return Ok("Updated Successfully");
        //}
    }
}
