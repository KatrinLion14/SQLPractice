using Microsoft.AspNetCore.Mvc;
using UniversityWebApi.Dto;
using UniversityWebApi.Services;

namespace UniversityWebApi.Controllers
{
    [ApiController]
    [Route("rest/{controller}")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }
        [HttpGet]
        public IActionResult GetStudents()
        {
            try
            {
                return Ok(_studentService.GetAllStudents()
                    .ConvertAll(t => t.ConvertToStudentDto()));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("{studentName}")]
        public IActionResult GetStudent(int studentId)
        {
            try
            {
                return Ok(_studentService.GetStudentById(studentId).ConvertToStudentDto());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Route("create")]
        public IActionResult CreateStudent([FromBody] StudentDto student)
        {
            try
            {
                return Ok(_studentService.CreateStudent(student));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        [Route("{studentName}/delete")]
        public IActionResult DeleteStudent(int studentId)
        {
            try
            {
                _studentService.DeleteStudent(studentId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        [Route("update")]
        public IActionResult UpdateStudent([FromBody] StudentDto student)
        {
            try
            {
                return Ok(_studentService.UpdateStudent(student));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
