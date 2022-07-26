using Microsoft.AspNetCore.Mvc;
using UniversityWebApi.Domain;
using UniversityWebApi.Dto;
using UniversityWebApi.Services;

namespace UniversityWebApi.Controllers
{
    [ApiController]
    [Route("rest/{controller}")]
    public class ProfessorController : ControllerBase
    {
        private readonly IProfessorService _professorService;
        public ProfessorController(IProfessorService professorService)
        {
            _professorService = professorService;
        }
        [HttpGet]
        public IActionResult GetProfessors()
        {
            try
            {
                return Ok(_professorService.GetAllProfessors()
                    .ConvertAll(t => t.ConvertToProfessorDto()));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("{professorEmail}")]
        public IActionResult GetProfessor(string professorEmail)
        {
            try
            {
                return Ok(_professorService.GetProfessorByEmail(professorEmail).ConvertToProfessorDto());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Route("create")]
        public IActionResult CreateProfessor([FromBody] ProfessorDto professor)
        {
            try
            {
                return Ok(_professorService.CreateProfessor(professor));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        [Route("{professorEmail}/delete")]
        public IActionResult DeleteProfessor(string professorEmail)
        {
            try
            {
                _professorService.DeleteProfessor(professorEmail);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        [Route("update")]
        public IActionResult UpdateProfessor([FromBody] ProfessorDto professor)
        {
            try
            {
                return Ok(_professorService.UpdateProfessor(professor));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
