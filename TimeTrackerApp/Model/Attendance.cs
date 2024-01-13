using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TimeTrackerApp.Model
{
    [Table("attendance")]
    public class Attendance
    {
        [Key, Required]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("date")]
        public DateTime Date { get; set; }

        [Required]
        [Column("start_time")]
        public DateTime StartTime { get; set; }

        [Required]
        [Column("end_time")]
        public DateTime EndTime { get; set; }

        [Required]
        [Column("timesheet_id")]
        [ForeignKey("Timesheet")]
        public int TimesheetId { get; set; }

        [Required]
        [Column("assignment_id")]
        [ForeignKey("Assignment")]
        public int AssignmentId { get; set; }
    }
}
