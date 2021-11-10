using FitnessPrograms.Model;
using FitnessPrograms.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft;
using FitnessPrograms.Filters;

namespace FitnessPrograms.Controllers
{
    [CustomExceptionFilterAttribute]
    [ApiController]
    [Route("api/[controller]")]
    public class ProgramsController : ControllerBase
    {
        private readonly IProgramsService _service;

        public ProgramsController(IProgramsService service)
        {
            this._service = service;
        }
        //[Authorize]
        [HttpGet]
        public IActionResult GetAllPrograms()
        {
            return Ok(JsonConvert.SerializeObject(_service.GetAllPrograms()));
        }
        [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetProgramById(int id)
        {
            return Ok(JsonConvert.SerializeObject(_service.GetProgramById(id)));
        }
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public IActionResult UpdateProgram(int id, Programs program)
        {
            return Ok(JsonConvert.SerializeObject(_service.UpdateProgram(id, program)));
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult AddPrograms(Programs program)
        {
            return Ok(JsonConvert.SerializeObject(_service.AddPrograms(program)));
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public IActionResult DeletePrograms(int id)
        {
            return Ok(JsonConvert.SerializeObject(_service.DeletePrograms(id)));
        }

    }
}
