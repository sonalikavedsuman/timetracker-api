using TimeTrackerApp.Dtos;
using TimeTrackerApp.Model;

namespace TimeTrackerApp.Services.AttendanceService
{
    public class AttendanceService : IAttendanceService
    {
        private readonly TimeTrackerDbContext _dbContext;

        public AttendanceService(TimeTrackerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<AttendanceDto> GetAllAttendances()
        {
            var attendances = _dbContext.Attendances.Select(a => new AttendanceDto
            {
                Id = a.Id,
                Date = a.Date,
                StartTime = a.StartTime,
                EndTime = a.EndTime,
                TimesheetId = a.TimesheetId,
                AssignmentId = a.AssignmentId
            }).ToList();

            return attendances;
        }

        public AttendanceDto GetAttendanceById(int attendanceId)
        {
            var attendance = _dbContext.Attendances
                .Where(a => a.Id == attendanceId)
                .Select(a => new AttendanceDto
                {
                    Id = a.Id,
                    Date = a.Date,
                    StartTime = a.StartTime,
                    EndTime = a.EndTime,
                    TimesheetId = a.TimesheetId,
                    AssignmentId = a.AssignmentId
                })
                .FirstOrDefault();

            return attendance;
        }

        public void AddAttendance(Attendance attendance)
        {
            _dbContext.Attendances.Add(attendance);
            _dbContext.SaveChanges();
        }

        public void UpdateAttendance(Attendance updatedAttendance)
        {
            var existingAttendance = _dbContext.Attendances.Find(updatedAttendance.Id);

            if (existingAttendance != null)
            {
                existingAttendance.Date = updatedAttendance.Date;
                existingAttendance.StartTime = updatedAttendance.StartTime;
                existingAttendance.EndTime = updatedAttendance.EndTime;
                existingAttendance.TimesheetId = updatedAttendance.TimesheetId;
                existingAttendance.AssignmentId = updatedAttendance.AssignmentId;

                _dbContext.SaveChanges();
            }
            // Handle the case where the attendance is not found (optional)
        }

        public void DeleteAttendance(int attendanceId)
        {
            var attendance = _dbContext.Attendances.Find(attendanceId);

            if (attendance != null)
            {
                _dbContext.Attendances.Remove(attendance);
                _dbContext.SaveChanges();
            }
            // Handle the case where the attendance is not found (optional)
        }
    }
}
