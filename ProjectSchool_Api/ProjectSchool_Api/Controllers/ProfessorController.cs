using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectSchool_Api.Data;
using ProjectSchool_Api.Models;
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
        private IRepository _repo;

        public ProfessorController(IRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _repo.GetAllProfessoressAsync(true);
                return Ok(result);
            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falhou");
            }
        } 

        [HttpGet("{ProfessorId}")]
        public async Task<IActionResult> GetByProfessorId(int professorId)
        {
            try
            {
                var result = await _repo.GetProfessorAsyncById(professorId, true);
                return Ok(result);
            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falhou");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Professor model)
        {
            try
            {
                _repo.Add(model);

                if (await _repo.SaveChangesAsync())
                    return Created($"/api/Professor/{model.Id}", model);
  
            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falhou");
            }

            return BadRequest();
        }

        [HttpPut("{ProfessorId}")]
        public async Task<IActionResult> Put(int professorId, Professor model)
        {
            try
            {
                var professor = await _repo.GetProfessorAsyncById(professorId, false);

                if (professor == null)
                    return NotFound();

                _repo.Update(model);

                if (await _repo.SaveChangesAsync())
                {
                    professor = await _repo.GetProfessorAsyncById(professorId, true);
                    return Created($"/api/Professor/{model.Id}", professor);
                }

            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falhou");
            }

            return BadRequest();
        }

        [HttpDelete("{ProfessorId}")]
        public async Task<IActionResult> Delete(int professorId)
        {
            try
            {
                var professor = await _repo.GetProfessorAsyncById(professorId, false);

                if (professor == null)
                    return NotFound();

                _repo.Update(professor);

                if (await _repo.SaveChangesAsync())
                {
                    professor = await _repo.GetProfessorAsyncById(professorId, true);
                    return Ok();
                }

            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falhou");
            }

            return BadRequest();
        }

    }
}
