using CourseFeeback.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CourseFeeback.Data
{
    public class CourseFeedbackContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=CourseFeedback;Trusted_Connection=True;");
        }
    }
}
