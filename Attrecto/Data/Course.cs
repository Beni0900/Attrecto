using System.ComponentModel.DataAnnotations;

namespace Attrecto.Data
{
    public class Course
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Url { get; set; }

        public ICollection<User> Users { get; set; } = [];
    }
}
