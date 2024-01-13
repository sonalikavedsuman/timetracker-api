using TimeTrackerApp.Dtos;
using TimeTrackerApp.Model;

namespace TimeTrackerApp.Services.ProjectUserService
{
    public class ProjectUserService : IProjectUserService
    {
        private readonly TimeTrackerDbContext _dbContext;

        public ProjectUserService(TimeTrackerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<ProjectUserDto> GetAllProjectUsers()
        {
            var projectUsers = _dbContext.ProjectUsers.Select(pu => new ProjectUserDto
            {
                Id = pu.Id,
                UserId = pu.UserId,
                ProjectId = pu.ProjectId
            }).ToList();

            return projectUsers;
        }

        public ProjectUserDto GetProjectUserById(int projectUserId)
        {
            var projectUser = _dbContext.ProjectUsers
                .Where(pu => pu.Id == projectUserId)
                .Select(pu => new ProjectUserDto
                {
                    Id = pu.Id,
                    UserId = pu.UserId,
                    ProjectId = pu.ProjectId
                })
                .FirstOrDefault();

            return projectUser;
        }

        public void AddProjectUser(ProjectUser projectUser)
        {
            _dbContext.ProjectUsers.Add(projectUser);
            _dbContext.SaveChanges();
        }

        public void UpdateProjectUser(ProjectUser updatedProjectUser)
        {
            var existingProjectUser = _dbContext.ProjectUsers.Find(updatedProjectUser.Id);

            if (existingProjectUser != null)
            {
                existingProjectUser.UserId = updatedProjectUser.UserId;
                existingProjectUser.ProjectId= updatedProjectUser.ProjectId;

                _dbContext.SaveChanges();
            }
            // Handle the case where the project user is not found (optional)
        }

        public void DeleteProjectUser(int projectUserId)
        {
            var projectUser = _dbContext.ProjectUsers.Find(projectUserId);

            if (projectUser != null)
            {
                _dbContext.ProjectUsers.Remove(projectUser);
                _dbContext.SaveChanges();
            }
            // Handle the case where the project user is not found (optional)
        }
    }
}
