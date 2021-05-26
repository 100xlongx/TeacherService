using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using App.Services;
using App.Models;

namespace App.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly ILogger<StudentController> _logger;
        private readonly StudentService _studentService;

        public StudentController(ILogger<StudentController> logger, StudentService studentService)
        {
            _logger = logger;
            _studentService = studentService;
        }

        [HttpGet]
        public IActionResult GetStudents()
        {
            List<StudentsInfo> students = _studentService.GetStudents();

            if(students.Count == 0) {
                return base.NoContent();
            }
            return base.Ok(students);
        }

        [HttpGet("{id}")]
        public IActionResult GetStudentByID(int id)
        {
            StudentsInfo student = _studentService.GetStudentById(id);
            if (student is null)
            {
                return base.NotFound("Could not find student");
            }
            return base.Ok(student);
        }

        [HttpPost]
        public IActionResult AddStudent([FromBody] StudentsInfo student)
        {
            return base.Accepted("Student Added");
        }

        [HttpPut]
        public IActionResult UpdateStudent([FromBody] StudentsInfo student)
        {
            if (_studentService.GetStudentById(student.Id) is not null)
            {
                _studentService.UpdateStudent(student);
                return base.Accepted("Student Updated");
            }
            else
            {
                return base.NotFound("Could not find student");
            }
        }

        [HttpDelete]
        public IActionResult RemoveStudentByID([FromBody] StudentsInfo student)
        {
            if (_studentService.GetStudentById(student.Id) is not null)
            {
                _studentService.DeleteStudent(student);
                return base.Accepted("Student Removed");
            }
            else
            {
                return base.NotFound("Could not find student");
            }

        }
    }
}
