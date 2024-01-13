using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TimeTrackerApp.Model;
using TimeTrackerApp.Services.AttendanceService;

namespace TimeTrackerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        private readonly IAttendanceService _attendanceService;

        public AttendanceController(IAttendanceService attendanceService)
        {
            _attendanceService = attendanceService;
        }

        [HttpGet]
        public IActionResult GetAllAttendances()
        {
            var attendances = _attendanceService.GetAllAttendances();
            return Ok(attendances);
        }

        [HttpGet("{id}")]
        public IActionResult GetAttendanceById(int id)
        {
            var attendance = _attendanceService.GetAttendanceById(id);

            if (attendance == null)
            {
                return NotFound(); // 404 Not Found
            }

            return Ok(attendance);
        }

        [HttpPost]
        public IActionResult AddAttendance([FromBody] Attendance attendance)
        {
            if (attendance == null)
            {
                return BadRequest(); // 400 Bad Request
            }

            _attendanceService.AddAttendance(attendance);

            return CreatedAtAction(nameof(GetAttendanceById), new { id = attendance.Id }, attendance);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAttendance(int id, [FromBody] Attendance updatedAttendance)
        {
            if (updatedAttendance == null || id != updatedAttendance.Id)
            {
                return BadRequest(); // 400 Bad Request
            }

            _attendanceService.UpdateAttendance(updatedAttendance);

            return NoContent(); // 204 No Content
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAttendance(int id)
        {
            _attendanceService.DeleteAttendance(id);

            return NoContent(); // 204 No Content
        }
    }
}
