using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TimeTrackerApp.Model;
using TimeTrackerApp.Services.TimesheetService;

namespace TimeTrackerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimesheetController : ControllerBase
    {
        private readonly ITimesheetService _timesheetService;

        public TimesheetController(ITimesheetService timesheetService)
        {
            _timesheetService = timesheetService;
        }

        [HttpGet]
        public IActionResult GetAllTimesheets()
        {
            var timesheets = _timesheetService.GetAllTimesheets();
            return Ok(timesheets);
        }

        [HttpGet("{id}")]
        public IActionResult GetTimesheetById(int id)
        {
            var timesheet = _timesheetService.GetTimesheetById(id);

            if (timesheet == null)
            {
                return NotFound(); // 404 Not Found
            }

            return Ok(timesheet);
        }

        [HttpPost]
        public IActionResult AddTimesheet([FromBody] Timesheet timesheet)
        {
            if (timesheet == null)
            {
                return BadRequest(); // 400 Bad Request
            }

            _timesheetService.AddTimesheet(timesheet);

            return CreatedAtAction(nameof(GetTimesheetById), new { id = timesheet.Id }, timesheet);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTimesheet(int id, [FromBody] Timesheet updatedTimesheet)
        {
            if (updatedTimesheet == null || id != updatedTimesheet.Id)
            {
                return BadRequest(); // 400 Bad Request
            }

            _timesheetService.UpdateTimesheet(updatedTimesheet);

            return NoContent(); // 204 No Content
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTimesheet(int id)
        {
            _timesheetService.DeleteTimesheet(id);

            return NoContent(); // 204 No Content
        }
    }
}
