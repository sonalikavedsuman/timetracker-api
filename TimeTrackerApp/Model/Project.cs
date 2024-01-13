using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TimeTrackerApp.Model
{
    [Table("projects")]
    public class Project
    {
        [Key, Required]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("project_name")]
        [MaxLength(255)]
        public string Name { get; set; }

        [Required]
        [Column("description")]
        [MaxLength(255)]
        public string Description { get; set; }

        [Required]
        [Column("client_name")]
        [MaxLength(255)]
        public string ClientName { get; set; }

        [Required]
        [Column("technologies")]
        [MaxLength(255)]
        public string Technology { get; set; }

        
    }
}
