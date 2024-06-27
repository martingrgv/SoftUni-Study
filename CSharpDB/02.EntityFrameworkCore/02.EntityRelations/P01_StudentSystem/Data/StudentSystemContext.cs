using Microsoft.EntityFrameworkCore;
using P01_StudentSystem.Data.Models;

namespace P01_StudentSystem.Data
{
    public class StudentSystemContext : DbContext
    {
        private const string connectionString = "Server=.;Database=StudentSystem;Integrated Security=True;";
        public StudentSystemContext()
        {

        }

        /// <summary>
        /// Constructs the database using existing options
        /// </summary>
        /// <param name="options">Options</param>
        public StudentSystemContext(DbContextOptions dbContextOptions)
            :base(dbContextOptions)
        {

        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<StudentCourse> StudentsCourses { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<Homework> Homeworks { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(connectionString);
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuring the composite primary key (StudentId and CourseId)
            modelBuilder.Entity<StudentCourse>()
                .HasKey(sc => new { sc.StudentId, sc.CourseId });

            base.OnModelCreating(modelBuilder);
        }
    }
}
