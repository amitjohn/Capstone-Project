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
    public class MemberShipController : ControllerBase
    {
        private readonly IMembershipService _service;

        public MemberShipController(IMembershipService service)
        {
            _service = service;
        }
        [Authorize]
        [HttpGet("{EnrollmentId}")]
        public IActionResult GetHistoryByEnrollmentId(string EnrollmentId)
        {
            return Ok(_service.GetHistoryById(EnrollmentId));
        }
        [Authorize]
        [HttpPut("{EnrollmentId}")]
        public IActionResult UpdateHistory(MembershipHistory history)
        {
            return Ok(_service.UpdateMembershipPeriod(history));
        }
    }
}
