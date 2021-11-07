using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnquiriesAPI.Models
{
    public class User : IdentityUser
    {
        public int UserId { get; set; }
        public string Role { get; set; }
        public string Password { get; set; }
        public string ContactNo { get; set; }
    }
}
