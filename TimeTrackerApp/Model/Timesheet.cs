using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TimeTrackerApp.Model
{
    [Table("timesheets")]
    public class Timesheet
    {
        [Key, Required]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("user_id")]
        [ForeignKey("User")]
        public int UserId { get; set; }

        [Required]
        [Column("project_id")]
        [ForeignKey("Project")]
        public int ProjectId { get; set; }

    }
}
