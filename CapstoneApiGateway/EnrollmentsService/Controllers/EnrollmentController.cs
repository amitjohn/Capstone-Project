using EnrollmentsService.Filters;
using EnrollmentsService.Model;
using EnrollmentsService.Models;
using EnrollmentsService.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace EnrollmentsService.Controllers
{
    [CustomExceptionFilterAttribute]
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentController : ControllerBase
    {
        private readonly IEnrollmentService _service;
        private readonly IHttpClientFactory _clientFactory;

        public EnrollmentController(IEnrollmentService service, IHttpClientFactory clientFactory)
        {
            this._service = service;
            _clientFactory = clientFactory;
        }
        [Authorize(Roles ="Admin, Employee")]
        [HttpGet("{programName}")]
        public IActionResult Get(string programName)
        {
            return Ok(_service.GetUserListByProgaramName(programName));
        }
        [Authorize]
        [HttpGet("member/{id}")]
        public IActionResult GetEnrollmentById(string id)
        {
            return Ok(_service.GetEnrolledMember(id));
        }
        [Authorize]
        [HttpPost]
        public IActionResult Post(Enrollment e, DateTime start, DateTime end)
        {
            return Ok(_service.AddEnrollment(e, start, end));
        }
        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Put(string id, Enrollment er)
        {
            return Ok(_service.UpdateEnrollmentDetails(id,er));
        }
        [Authorize(Roles = "Admin, Employee")]
        [HttpGet("fetch/{UserName}")]
        public async Task<IActionResult> fetchUserDetails(string UserName)
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
           $"https://localhost:44317/api/User/profile/{UserName}");
            request.Headers.Add("Accept", "application/vnd.github.v3+json");
            request.Headers.Add("User-Agent", "HttpClientFactory-Sample");
            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                var result = await JsonSerializer.DeserializeAsync<User>(responseStream);
                return Ok(result);
            }
            else
            {
                return NotFound("User not Found");
            }
        }
        [Authorize]
        [HttpGet("membership/{id}")]
        public IActionResult GetMembershipStatus(string id)
        {
            return Ok(_service.checkMemberShipStatus(id));
        }

    }
}
