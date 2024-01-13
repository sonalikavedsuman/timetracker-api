using TimeTrackerApp.Model;

namespace TimeTrackerApp.Dtos
{
    public class ProjectUserDto
    {
            public int Id { get; set; }
            public int UserId { get; set; }
            public int ProjectId { get; set; }
    }
}
