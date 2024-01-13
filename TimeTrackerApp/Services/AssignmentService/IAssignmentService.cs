using TimeTrackerApp.Dtos;
using TimeTrackerApp.Model;

namespace TimeTrackerApp.Services.AssignmentService
{
    public interface IAssignmentService
    {
        IEnumerable<AssignmentDto> GetAllAssignments();
        AssignmentDto GetAssignmentById(int assignmentId);
        void AddAssignment(Assignment assignment);
        void UpdateAssignment(Assignment assignment);
        void DeleteAssignment(int assignmentId);
    }
}
