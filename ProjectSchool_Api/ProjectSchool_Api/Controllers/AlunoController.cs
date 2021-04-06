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
    public class AlunoController : Controller
    {
        private readonly IRepository _repo;

        public AlunoController(IRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _repo.GetAllAlunosAsync(true);
                return Ok(result);
            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falhou");
            }
        }

        [HttpGet("ByProfessor/{ProfessorId}")]
        public async Task<IActionResult> GetByProfessorId(int professorId)
        {
            try
            {
                var result = await _repo.GetAlunosAsyncByProfessorId(professorId, true);
                return Ok(result);
            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falhou");
            }
        }

        [HttpGet("{AlunoId}")]
        public async Task<IActionResult> GetByAlunoId(int alunoId)
        {
            try
            {
                var result = await _repo.GetAlunosAsyncById(alunoId, true);
                return Ok(result);
            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falhou");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Aluno model)
        {
            try
            {
                _repo.Add(model);

                if(await _repo.SaveChangesAsync())
                    return Created($"/api/aluno/{model.Id}", model);

            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falhou");
            }

            return BadRequest();
        }

        [HttpPut("{AlunoId}")]
        public async Task<IActionResult> Put(int alunoId, Aluno model)
        {
            try
            {
                var aluno = await _repo.GetAlunosAsyncById(alunoId, false);

                if (aluno == null)
                    return NotFound();

                _repo.Update(model);

                if (await _repo.SaveChangesAsync())
                {
                    aluno = await _repo.GetAlunosAsyncById(alunoId, true);
                    return Created($"/api/aluno/{model.Id}", aluno);
                }
                    
            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falhou");
            }

            return BadRequest();
        }

        [HttpDelete("{AlunoId}")]
        public async Task<IActionResult> Delete(int alunoId)
        {
            try
            {
                var aluno = await _repo.GetAlunosAsyncById(alunoId, false);

                if (aluno == null)
                    return NotFound();

                _repo.Delete(aluno);

                if (await _repo.SaveChangesAsync())
                {
                    aluno = await _repo.GetAlunosAsyncById(alunoId, false);
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
