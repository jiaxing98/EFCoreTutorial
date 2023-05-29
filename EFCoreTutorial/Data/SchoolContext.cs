using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EFCoreTutorial.Models;

namespace EFCoreTutorial.Data
{
    public class SchoolContext : DbContext
    {
        public SchoolContext (DbContextOptions<SchoolContext> options)
            : base(options)
        {
        }
		public DbSet<Enrollment> Enrollments { get; set; }
		public DbSet<Course> Courses { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<OfficeAssignment> OfficeAssignments { get; set; }
		public DbSet<Person> People { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
			modelBuilder.Entity<Course>().ToTable(nameof(Course))
                .HasMany(c => c.Instructors)
                .WithMany(i => i.Courses);

			modelBuilder.Entity<Person>().UseTpcMappingStrategy();
			modelBuilder.Entity<Student>().ToTable(nameof(Student));
			modelBuilder.Entity<Instructor>().ToTable(nameof(Instructor));

		}
	}
}
