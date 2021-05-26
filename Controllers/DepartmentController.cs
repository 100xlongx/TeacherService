using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using App.Services;
using App.Models;

namespace App.Controllers {

    [ApiController]
    [Route("[controller]")]
    public class DepartmentController : ControllerBase
    {
        private readonly DepartmentService _departmentService;

        public DepartmentController(DepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet]
        public IActionResult GetDepartment()
        {
            List<DepartmentInfo> students = _departmentService.GetDepartments();

            if(students.Count == 0) {
                return base.NoContent();
            }

            return base.Ok(students);
        }

        [HttpGet("{id}")]
        public IActionResult GetDepartmentById(int id)
        {
            DepartmentInfo student = _departmentService.GetDepartmentById(id);
            if (student is null)
            {
                return base.NotFound("Could not find student");
            }
            return base.Ok(student);
        }

        [HttpPost]
        public IActionResult AddDepartment([FromBody] DepartmentInfo department)
        {
            _departmentService.addDepartment(department);
            return base.Accepted("Department Added");
        }

        [HttpDelete]
        public IActionResult DeleteDepartment([FromBody] DepartmentInfo department)
        {
            _departmentService.removeDepartment(department);
            return base.Accepted("Department Removed");
        }

        [HttpPut]
        public IActionResult UpdateDepartment([FromBody] DepartmentInfo department)
        {
            _departmentService.updateDepartment(department);
            return base.Accepted("Department updated");
        }
    }
}