using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymUserApi.Model
{
    public class User : IdentityUser
    {
        public string Role { get; set; }   
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public override string Email { get; set; }
        public string ContactNo { get; set; }
    }
}
