using GymUserApi.Model;
using GymUserApi.Repository;
using GymUserApi.Service;
using Microsoft.AspNetCore.Authorization;
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
        private readonly ITokenGeneratorService _service;
        private readonly IUserRepository repo;

        public UserController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, ITokenGeneratorService service, IUserRepository repo)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _service = service;
            this.repo = repo;
        }
        [HttpPost("register")]
        public IActionResult CreateUser(User user)
        {
            if (repo.CreateUser(user).Result.Equals(true)) 
            { 
                return Ok("true");
            }
            else
            {
                return Conflict("User Registration failed");
            }
        }
        [Authorize(Roles = "Admin")]
        [HttpPost("admin/register")]
        public IActionResult CreateUserAdmin(User user)
        {
            if (repo.CreateUser(user).Result.Equals(true))
            {
                return Ok("true");
            }
            else
            {
                return Conflict("User Registration failed");
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
                var authClaims = new[]
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
    }
}