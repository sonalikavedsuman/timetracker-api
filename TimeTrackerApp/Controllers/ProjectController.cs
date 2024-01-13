using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TimeTrackerApp.Model;
using TimeTrackerApp.Services.ProjectService;

namespace TimeTrackerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet]
        public IActionResult GetAllProjects()
        {
            var projects = _projectService.GetAllProjects();
            return Ok(projects);
        }

        [HttpGet("{id}")]
        public IActionResult GetProjectById(int id)
        {
            var project = _projectService.GetProjectById(id);

            if (project == null)
            {
                return NotFound(); // 404 Not Found
            }

            return Ok(project);
        }

        [HttpPost]
        public IActionResult AddProject([FromBody] Project project)
        {
            if (project == null)
            {
                return BadRequest(); // 400 Bad Request
            }

            _projectService.AddProject(project);

            return CreatedAtAction(nameof(GetProjectById), new { id = project.Id }, project);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProject(int id, [FromBody] Project updatedProject)
        {
            if (updatedProject == null || id != updatedProject.Id)
            {
                return BadRequest(); // 400 Bad Request
            }

            _projectService.UpdateProject(updatedProject);

            return NoContent(); // 204 No Content
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProject(int id)
        {
            var project = _projectService.GetProjectById(id);

            if (project == null)
            {
                return NotFound($"Project with ID {id} not found.");
            }

            _projectService.DeleteProject(id);

            return NoContent(); // 204 No Content
        }
    }
}
