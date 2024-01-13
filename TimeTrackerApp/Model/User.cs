using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TimeTrackerApp.Model
{
    [Table("users")]
    public class User
    {
        [Key, Required]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("first_name")]
        [MaxLength(255)]
        public string FirstName { get; set; }

        [Required]
        [Column("last_name")]
        [MaxLength(255)]
        public string LastName { get; set; }

        [Required]
        [Column("email")]
        [MaxLength(255)]
        public string Email { get; set; }

        [Required]
        [Column("password")]
        [MaxLength(255)]
        public string Password { get; set; }

        [Required]
        [Column("phone")]
        [MaxLength(15)]
        public string Phone { get; set; }

       
    }
}
