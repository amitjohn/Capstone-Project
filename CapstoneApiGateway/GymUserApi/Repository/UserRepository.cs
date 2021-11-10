using GymUserApi.Model;
using GymUserApi.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace GymUserApi.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly ITokenGeneratorService _service;
        public UserRepository(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration, ITokenGeneratorService service)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _service = service;
        }
        public async Task<bool> CreateUser(User user)
        {
            var u = new IdentityUser()
            {
                Email = user.Email,
                UserName = user.UserName,
                PhoneNumber = user.PhoneNumber
            };
            var claimsToAdd = new List<Claim>() {
                new Claim(ClaimTypes.GivenName, user.FirstName),
                new Claim(ClaimTypes.Surname, user.LastName)
                };

            var result = await _userManager.CreateAsync(u, user.Password);
            var addClaimsResult = await _userManager.AddClaimsAsync(u, claimsToAdd);

            if (result.Succeeded)
            {
                if (user.Role.Equals("Member"))
                {
                    await _roleManager.CreateAsync(new IdentityRole("Member"));
                    await _userManager.AddToRoleAsync(u, "Member");
                }
                else if (user.Role.Equals("Employee"))
                {
                    await _roleManager.CreateAsync(new IdentityRole("Employee"));
                    await _userManager.AddToRoleAsync(u, "Employee");
                }else if (user.Role.Equals("Admin"))
                {
                    await _roleManager.CreateAsync(new IdentityRole("Admin"));
                    await _userManager.AddToRoleAsync(u, "Admin");
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Login(User user)
        {
            throw new NotImplementedException();
        }
    }
}
