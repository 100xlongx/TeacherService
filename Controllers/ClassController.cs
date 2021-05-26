using System.Collections.Generic;
using App.Models;
using App.Services;
using Microsoft.AspNetCore.Mvc;

namespace TeacherService.Controllers
{
    namespace App.Controllers {

    [ApiController]
    [Route("[controller]")]
    public class ClassController : ControllerBase
    {
        private readonly ClassService _classService;

        public ClassController(ClassService classService)
        {
            _classService = classService;
        }

        [HttpGet]
        public IActionResult GetDepartment()
        {
            List<ClassInfo> students = _classService.GetClasses();

            if(students.Count == 0) {
                return base.NoContent();
            }

            return base.Ok(students);
        }

        [HttpGet("{id}")]
        public IActionResult GetDepartmentById(int id)
        {
            ClassInfo student = _classService.GetClassById(id);
            if (student is null)
            {
                return base.NotFound("Could not find student");
            }
            return base.Ok(student);
        }

        [HttpPost]
        public IActionResult AddClass([FromBody] ClassInfo classInfo)
        {
            _classService.addClass(classInfo);
            return base.Accepted("Class Added");
        }

        [HttpDelete]
        public IActionResult DeleteClass([FromBody] ClassInfo classInfo)
        {
            _classService.removeClass(classInfo);
            return base.Accepted("Class Removed");
        }

        [HttpPut]
        public IActionResult updateClass([FromBody] ClassInfo classInfo)
        {
            _classService.updateClass(classInfo);
            return base.Accepted("Class updated");
        }
    }
    }
}