using System.ComponentModel.DataAnnotations;

namespace Attrecto.Data
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string? FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string? LastName { get; set; }

        [Required]
        public string? Email { get; set; }
        [Required]
        public int? Age { get; set; }
        [Required]
        public string? Password { get; set; }

        public ICollection<Course> Courses { get; set; } = [];

    }
}
