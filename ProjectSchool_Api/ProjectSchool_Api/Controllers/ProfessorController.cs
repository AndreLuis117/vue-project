using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectSchool_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorController : Controller
    {

        public ProfessorController()
        {
              
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        } 
        [HttpGet("{ProfessorId}")]
        public IActionResult Get(int ProfessorId)
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult Post()
        {
            return Ok();
        }

        [HttpPut("{ProfessorId}")]
        public IActionResult Put(int ProfessorId)
        {
            return Ok();
        }

        [HttpDelete("{ProfessorId}")]
        public IActionResult Delete(int ProfessorId)
        {
            return Ok();
        }

    }
}
