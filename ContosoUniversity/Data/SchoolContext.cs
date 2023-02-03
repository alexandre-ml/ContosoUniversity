using ContosoUniversity.Models;
using Microsoft.EntityFrameworkCore;

namespace ContosoUniversity.Data
{
    public class SchoolContext : DbContext
    {
        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)
        { 

        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Student> Students { get; set; }        
        public DbSet<Department> Departments { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<OfficeAssignment> OfficeAssignments { get; set; }
        public DbSet<CourseAssignment> CourseAssignments { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Course>().ToTable("Course");
            mb.Entity<Enrollment>().ToTable("Enrollment");
            mb.Entity<Student>().ToTable("Student");
            mb.Entity<Department>().ToTable("Department");
            mb.Entity<Instructor>().ToTable("Instructor");
            mb.Entity<OfficeAssignment>().ToTable("OfficeAssignment");
            mb.Entity<CourseAssignment>().ToTable("CourseAssignment");

            //configurar chave composta
            mb.Entity<CourseAssignment>()
                .HasKey(c => new
                {
                    c.CourseID,
                    c.InstructorID
                });
        }
    }
}
