using TimeTrackerApp.Dtos;
using TimeTrackerApp.Model;

namespace TimeTrackerApp.Services.ProjectUserService
{
    public interface IProjectUserService
    {
        IEnumerable<ProjectUserDto> GetAllProjectUsers();
        ProjectUserDto GetProjectUserById(int projectUserId);
        void AddProjectUser(ProjectUser projectUser);
        void UpdateProjectUser(ProjectUser projectUser);
        void DeleteProjectUser(int projectUserId);
    }
}
