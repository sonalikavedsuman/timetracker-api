using TimeTrackerApp.Dtos;
using TimeTrackerApp.Model;

namespace TimeTrackerApp.Services.AssignmentService
{
    public class AssignmentService : IAssignmentService
    {
        private readonly TimeTrackerDbContext _dbContext;

        public AssignmentService(TimeTrackerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<AssignmentDto> GetAllAssignments()
        {
            var assignments = _dbContext.Assignments.Select(a => new AssignmentDto
            {
                Id = a.Id,
                Name = a.Name,
                Description = a.Description
            }).ToList();

            return assignments;
        }

        public AssignmentDto GetAssignmentById(int assignmentId)
        {
            var assignment = _dbContext.Assignments
                .Where(a => a.Id == assignmentId)
                .Select(a => new AssignmentDto
                {
                    Id = a.Id,
                    Name = a.Name,
                    Description = a.Description
                })
                .FirstOrDefault();

            return assignment;
        }

        public void AddAssignment(Assignment assignment)
        {
            _dbContext.Assignments.Add(assignment);
            _dbContext.SaveChanges();
        }

        public void UpdateAssignment(Assignment updatedAssignment)
        {
            var existingAssignment = _dbContext.Assignments.Find(updatedAssignment.Id);

            if (existingAssignment != null)
            {
                existingAssignment.Name = updatedAssignment.Name;
                existingAssignment.Description = updatedAssignment.Description;

                _dbContext.SaveChanges();
            }
            // Handle the case where the assignment is not found (optional)
        }

        public void DeleteAssignment(int assignmentId)
        {
            var assignment = _dbContext.Assignments.Find(assignmentId);

            if (assignment != null)
            {
                _dbContext.Assignments.Remove(assignment);
                _dbContext.SaveChanges();
            }
            // Handle the case where the assignment is not found (optional)
        }
    }
}
