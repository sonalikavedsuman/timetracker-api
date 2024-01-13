using TimeTrackerApp.Dtos;
using TimeTrackerApp.Model;

namespace TimeTrackerApp.Services.TimesheetService
{
    public interface ITimesheetService
    {
        IEnumerable<TimesheetDto> GetAllTimesheets();
        TimesheetDto GetTimesheetById(int timesheetId);
        void AddTimesheet(Timesheet timesheet);
        void UpdateTimesheet(Timesheet timesheet);
        void DeleteTimesheet(int timesheetId);
    }
}
