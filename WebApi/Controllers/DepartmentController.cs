using Microsoft.AspNetCore.Mvc;
using UniversityWebApi.Domain;
using UniversityWebApi.Dto;
using UniversityWebApi.Services;

namespace UniversityWebApi.Controllers
{
    [ApiController]
    [Route("rest/{controller}")]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;
        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }
        [HttpGet]
        public IActionResult GetDepartments()
        {
            try
            {
                return Ok(_departmentService.GetDepartments()
                    .ConvertAll(t => t.ConvertToDepartmentDto()));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("{departmentName}")]
        public IActionResult GetDepartment(string departmentName)
        {
            try
            {
                return Ok(_departmentService.GetDepartmentByName(departmentName).ConvertToDepartmentDto());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Route("create")]
        public IActionResult CreateDepartment([FromBody] DepartmentDto department)
        {
            try
            {
                return Ok(_departmentService.CreateDepartment(department));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        [Route("{departmentName}/delete")]
        public IActionResult DeleteDepartment(string departmentName)
        {
            try
            {
                _departmentService.DeleteDepartment(departmentName);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        [Route("update")]
        public IActionResult UpdateDepartment([FromBody] DepartmentDto department)
        {
            try
            {
                return Ok(_departmentService.UpdateDepartment(department));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        [Route("update/{departmentName}")]
        public IActionResult UpdateDepartmentOfficeByName(string departmentName, [FromBody] int office)
        {
            try
            {
                Department department = _departmentService.GetDepartmentByName(departmentName);
                department.Office = office;
                return Ok(_departmentService.UpdateDepartment(department.ConvertToDepartmentDto()));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("count_by_address")]
        public IActionResult GetDepartmentCountByAddress()
        {
            try
            {
                return Ok(_departmentService.GetDepartmentCountGroupByAddress());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
