using Microsoft.EntityFrameworkCore;

namespace Attrecto.Data
{
    public class ApplicationDbContext : DbContext
    {
        private readonly string DbPath;

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Course> Courses { get; set; }
    }
}