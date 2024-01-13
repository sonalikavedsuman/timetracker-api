using TimeTrackerApp.Model;

namespace TimeTrackerApp.Dtos
{
    public class AttendanceDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int TimesheetId { get; set; }
        public int AssignmentId { get; set; }
    }
}
