using TimeTrackerApp.Dtos;
using TimeTrackerApp.Model;

namespace TimeTrackerApp.Services.AttendanceService
{
    public interface IAttendanceService
    {
        IEnumerable<AttendanceDto> GetAllAttendances();
        AttendanceDto GetAttendanceById(int attendanceId);
        void AddAttendance(Attendance attendance);
        void UpdateAttendance(Attendance attendance);
        void DeleteAttendance(int attendanceId);
    }
}
