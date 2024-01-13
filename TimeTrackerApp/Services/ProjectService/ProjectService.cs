using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TimeTrackerApp.Dtos;
using TimeTrackerApp.Model;
using TimeTrackerApp.Services.ProjectService;

namespace TimeTrackerApp.Services.ProjectService 
{
    public class ProjectService : IProjectService
    {
        private readonly TimeTrackerDbContext _dbContext;

        public ProjectService(TimeTrackerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<ProjectDto> GetAllProjects()
        {
            var projects = _dbContext.Projects.Select(p => new ProjectDto
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                ClientName = p.ClientName,
                Technology = p.Technology
            }).ToList();

            return projects;
        }

        public ProjectDto GetProjectById(int projectId)
        {
            var project = _dbContext.Projects
                .Where(p => p.Id == projectId)
                .Select(p => new ProjectDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    ClientName = p.ClientName,
                    Technology = p.Technology
                })
                .FirstOrDefault();

            return project;
        }

        public void AddProject(Project project)
        {
            _dbContext.Projects.Add(project);
            _dbContext.SaveChanges();
        }
        public void UpdateProject(Project updatedProject)
        {
            var existingProject = _dbContext.Projects.Find(updatedProject.Id);
            if (existingProject != null)
            {
                existingProject.Id = updatedProject.Id;
                existingProject.Name = updatedProject.Name;
                existingProject.Description = updatedProject.Description;
                existingProject.ClientName = updatedProject.ClientName;
                existingProject.Technology = updatedProject.Technology;
               _dbContext.SaveChanges();
            }
                // Handle the case where the project is not found (optional)
        }
        

        public void DeleteProject(int projectId)
        {
            var project = _dbContext.Projects.Find(projectId);

            if (project != null)
            {
                _dbContext.Projects.Remove(project);
                _dbContext.SaveChanges();
            }
            // Handle the case where the project is not found (optional)
        }
    }

    }

