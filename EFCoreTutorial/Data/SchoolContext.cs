﻿using System;
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
		public DbSet<Student> Students { get; set; }
		public DbSet<Enrollment> Enrollments { get; set; }
		public DbSet<Course> Courses { get; set; }
	}
}
