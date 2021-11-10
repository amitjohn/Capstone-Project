using EnquiriesAPI.Exceptions;
using EnquiriesAPI.Models;
using EnquiriesAPI.Repository;
using EnquiriesAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnquiriesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnquiryController : ControllerBase
    {
        private readonly IEnquiryService service;

        public EnquiryController(IEnquiryService service)
        {
            this.service = service;
        }
        [Authorize(Roles = "Admin, Employee")]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(JsonConvert.SerializeObject(service.GetEnquiries()));
            }
            catch (EnquiryNotFoundException e)
            {
                return NotFound(e.Message);
            }
        }
        [Authorize(Roles = "Admin, Employee")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                service.DeleteEnquiry(id);
                return Ok(JsonConvert.SerializeObject("Enquiry Deleteed Succesfully"));
            }
            catch (EnquiryNotFoundException e)
            {
                return NotFound(e.Message);
            }  
        }

        [Authorize(Roles ="Admin, Employee")]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
               return Ok(JsonConvert.SerializeObject(service.GetEnquiryById(id)));
            }
            catch(EnquiryNotFoundException e)
            {
                return NotFound(e.Message);
            }
            
        }
        [Authorize(Roles = "Employee, Member")]
        [HttpPost]
        public IActionResult Post(Enquiry enquiry)
        {
            try
            {
                service.PostEnquiry(enquiry);
                return StatusCode(201, JsonConvert.SerializeObject("Your Enquiry is Submitted"));
            }catch(EnquiryAlradyExistsException e)
            {
                return NotFound(e.Message);
            }         
        }

        [Authorize(Roles ="Admin, Employee")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromForm] string Remarks)
        {
            try
            {
                service.EnquiryStatusUpdate(id, Remarks);
                return Ok(JsonConvert.SerializeObject("Enquiry Updated"));
            }
            catch (EnquiryNotFoundException e)
            {
                return NotFound(e.Message);
            }
        }
    }
}
