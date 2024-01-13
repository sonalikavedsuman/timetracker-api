using TimeTrackerApp.Dtos;
using TimeTrackerApp.Model;

namespace TimeTrackerApp.Services.TimesheetService
{
    public class TimesheetService : ITimesheetService
    {
        private readonly TimeTrackerDbContext _dbContext;

        public TimesheetService(TimeTrackerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<TimesheetDto> GetAllTimesheets()
        {
            var timesheets = _dbContext.Timesheets.Select(t => new TimesheetDto
            {
                Id = t.Id,
                UserId = t.UserId,
                ProjectId = t.ProjectId
            }).ToList();

            return timesheets;
        }

        public TimesheetDto GetTimesheetById(int timesheetId)
        {
            var timesheet = _dbContext.Timesheets
                .Where(t => t.Id == timesheetId)
                .Select(t => new TimesheetDto
                {
                    Id = t.Id,
                    UserId = t.UserId,
                    ProjectId = t.ProjectId
                })
                .FirstOrDefault();

            return timesheet;
        }

        public void AddTimesheet(Timesheet timesheet)
        {
            _dbContext.Timesheets.Add(timesheet);
            _dbContext.SaveChanges();
        }

        public void UpdateTimesheet(Timesheet updatedTimesheet)
        {
            var existingTimesheet = _dbContext.Timesheets.Find(updatedTimesheet.Id);

            if (existingTimesheet != null)
            {
                existingTimesheet.UserId = updatedTimesheet.UserId;
                existingTimesheet.ProjectId = updatedTimesheet.ProjectId;

                _dbContext.SaveChanges();
            }
            // Handle the case where the timesheet is not found (optional)
        }

        public void DeleteTimesheet(int timesheetId)
        {
            var timesheet = _dbContext.Timesheets.Find(timesheetId);

            if (timesheet != null)
            {
                _dbContext.Timesheets.Remove(timesheet);
                _dbContext.SaveChanges();
            }
            // Handle the case where the timesheet is not found (optional)
        }
    }
}
