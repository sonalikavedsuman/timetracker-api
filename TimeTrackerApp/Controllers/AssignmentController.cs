using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TimeTrackerApp.Model;
using TimeTrackerApp.Services.AssignmentService;

namespace TimeTrackerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignmentController : ControllerBase
    {
        private readonly IAssignmentService _assignmentService;

        public AssignmentController(IAssignmentService assignmentService)
        {
            _assignmentService = assignmentService;
        }

        [HttpGet]
        public IActionResult GetAllAssignments()
        {
            var assignments = _assignmentService.GetAllAssignments();
            return Ok(assignments);
        }

        [HttpGet("{id}")]
        public IActionResult GetAssignmentById(int id)
        {
            var assignment = _assignmentService.GetAssignmentById(id);

            if (assignment == null)
            {
                return NotFound(); // 404 Not Found
            }

            return Ok(assignment);
        }

        [HttpPost]
        public IActionResult AddAssignment([FromBody] Assignment assignment)
        {
            if (assignment == null)
            {
                return BadRequest(); // 400 Bad Request
            }

            _assignmentService.AddAssignment(assignment);

            return CreatedAtAction(nameof(GetAssignmentById), new { id = assignment.Id }, assignment);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAssignment(int id, [FromBody] Assignment updatedAssignment)
        {
            if (updatedAssignment == null || id != updatedAssignment.Id)
            {
                return BadRequest(); // 400 Bad Request
            }

            _assignmentService.UpdateAssignment(updatedAssignment);

            return NoContent(); // 204 No Content
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAssignment(int id)
        {
            _assignmentService.DeleteAssignment(id);

            return NoContent(); // 204 No Content
        }
    }
}
