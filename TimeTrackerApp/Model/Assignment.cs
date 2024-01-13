using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TimeTrackerApp.Model
{
    [Table("assignments")]
    public class Assignment
    {
        [Key, Required]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("assignment_name")]
        [MaxLength(255)]
        public string Name { get; set; }

        [Required]
        [Column("description")]
        [MaxLength(255)]
        public string Description { get; set; }

    }
}
