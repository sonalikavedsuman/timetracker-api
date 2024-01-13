using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TimeTrackerApp.Model;
using TimeTrackerApp.Services.ProjectUserService;

namespace TimeTrackerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectUserController : ControllerBase
    {
        private readonly IProjectUserService _projectUserService;

        public ProjectUserController(IProjectUserService projectUserService)
        {
            _projectUserService = projectUserService;
        }

        [HttpGet]
        public IActionResult GetAllProjectUsers()
        {
            var projectUsers = _projectUserService.GetAllProjectUsers();
            return Ok(projectUsers);
        }

        [HttpGet("{id}")]
        public IActionResult GetProjectUserById(int id)
        {
            var projectUser = _projectUserService.GetProjectUserById(id);

            if (projectUser == null)
            {
                return NotFound(); // 404 Not Found
            }

            return Ok(projectUser);
        }

        [HttpPost]
        public IActionResult AddProjectUser([FromBody] ProjectUser projectUser)
        {
            if (projectUser == null)
            {
                return BadRequest(); // 400 Bad Request
            }

            _projectUserService.AddProjectUser(projectUser);

            return CreatedAtAction(nameof(GetProjectUserById), new { id = projectUser.Id }, projectUser);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProjectUser(int id, [FromBody] ProjectUser updatedProjectUser)
        {
            if (updatedProjectUser == null || id != updatedProjectUser.Id)
            {
                return BadRequest(); // 400 Bad Request
            }

            _projectUserService.UpdateProjectUser(updatedProjectUser);

            return NoContent(); // 204 No Content
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProjectUser(int id)
        {
            _projectUserService.DeleteProjectUser(id);

            return NoContent(); // 204 No Content
        }
    }
}
