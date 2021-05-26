using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using App.Services;
using App.Models;

namespace App.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TeacherController : ControllerBase
    {
        private readonly ILogger<TeacherController> _logger;
        private readonly TeacherService _teacherService;

        public TeacherController(ILogger<TeacherController> logger, TeacherService teacherService)
        {
            _logger = logger;
            _teacherService = teacherService;
        }

        [HttpGet]
        public IActionResult GetTeachers()
        {
            List<TeachersInfo> teachers = _teacherService.GetTeachers();

            if(teachers.Count == 0) {
                return base.NoContent();
            }
            return base.Ok(teachers);

        }

        [HttpGet("{id}")]
        public IActionResult GetTeacherByID(int id)
        {
            TeachersInfo teacher = _teacherService.GetTeacherById(id);
            if(teacher is null) {
                return base.NotFound("This teacher does not exist");
            }
            return base.Ok(teacher);
        }

        [HttpPost]
        public IActionResult AddTeacher([FromBody] TeachersInfo Teacher)
        {
            _teacherService.AddTeacher(Teacher);
            return base.Accepted("Teacher Added");
        }
    }
}
