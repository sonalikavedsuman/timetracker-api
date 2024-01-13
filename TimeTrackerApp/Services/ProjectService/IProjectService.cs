using TimeTrackerApp.Dtos;
using TimeTrackerApp.Model;

namespace TimeTrackerApp.Services.ProjectService
{
    public interface IProjectService
    {
        IEnumerable<ProjectDto> GetAllProjects();
        ProjectDto GetProjectById(int projectId);
        void AddProject(Project project);
        void UpdateProject(Project project);
        void DeleteProject(int projectId);
    }
}
