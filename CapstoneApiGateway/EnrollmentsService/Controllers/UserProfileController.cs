using EnrollmentsService.Filters;
using EnrollmentsService.Model;
using EnrollmentsService.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnrollmentsService.Controllers
{
    [CustomExceptionFilterAttribute]
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private readonly IUserProfileService _service;

        public UserProfileController(IUserProfileService service)
        {
            _service = service;
        }
        [Authorize]
        [HttpPost]
        public IActionResult CreateProfile(UserProfile profile)
        {
            return Ok(_service.AddUserProfile(profile));
        }
        [Authorize]
        [HttpGet("nutrition/{EnrollmentId}")]
        public IActionResult getNutrition(string EnrollmentId)
        {
            return Ok(_service.CalculateNutrition(EnrollmentId));
        }
        [Authorize]
        [HttpPut("{EnrollmentId}")]
        public IActionResult UpdateDetails(string EnrollmentId, UserProfile profile)
        {
            return Ok(_service.UpdateProfile(EnrollmentId, profile));
        }
    }
}
