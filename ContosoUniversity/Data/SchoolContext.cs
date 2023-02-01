﻿using ContosoUniversity.Models;
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

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Course>().ToTable("Course");
            mb.Entity<Enrollment>().ToTable("Enrollment");
            mb.Entity<Student>().ToTable("Student");
        }
    }
}
