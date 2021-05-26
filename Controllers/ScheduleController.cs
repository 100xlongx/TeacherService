using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using App.Services;
using App.Models;

namespace App.Controllers {

    [ApiController]
    [Route("[controller]")]
    public class ScheduleController : ControllerBase
    {
        private readonly ScheduleService _scheduleService;

        public ScheduleController(ScheduleService scheduleService)
        {
            _scheduleService = scheduleService;
        }

        [HttpGet]
        public IActionResult GetSchedule()
        {
            List<ScheduleInfo> students = _scheduleService.GetSchedules();

            if(students.Count == 0) {
                return base.NoContent();
            }

            return base.Ok(students);
        }

        [HttpGet("{id}")]
        public IActionResult GetScheduleById(int id)
        {
            ScheduleInfo student = _scheduleService.GetScheduleById(id);
            if (student is null)
            {
                return base.NotFound("Could not find student");
            }
            return base.Ok(student);
        }

        [HttpPost]
        public IActionResult AddSchedule([FromBody] ScheduleInfo schedule)
        {
            _scheduleService.addSchedule(schedule);
            return base.Accepted("Department Added");
        }

        [HttpDelete]
        public IActionResult DeleteSchedule([FromBody] ScheduleInfo schedule)
        {
            _scheduleService.removeSchedule(schedule);
            return base.Accepted("Department Removed");
        }

        [HttpPut]
        public IActionResult UpdateSchedule([FromBody] ScheduleInfo schedule)
        {
            _scheduleService.updateSchedule(schedule);
            return base.Accepted("Department updated");
        }
    }
}