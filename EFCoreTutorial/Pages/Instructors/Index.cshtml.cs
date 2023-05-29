﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EFCoreTutorial.Data;
using EFCoreTutorial.Models;
using EFCoreTutorial.Models.SchoolViewModels;

namespace EFCoreTutorial.Pages.Instructors
{
    public class IndexModel : PageModel
    {
        private readonly SchoolContext _context;

        public IndexModel(SchoolContext context)
        {
            _context = context;
        }

		public InstructorIndexData InstructorData { get; set; }
		public int InstructorID { get; set; }
		public int CourseID { get; set; }

		public async Task OnGetAsync(int? id, int? courseID)
        {
			InstructorData = new InstructorIndexData();
			InstructorData.Instructors = await _context.Instructors
				.Include(i => i.OfficeAssignment)
				.Include(i => i.Courses)
					.ThenInclude(c => c.Department)
				.OrderBy(i => i.LastName)
				.ToListAsync();

			if (id != null)
			{
				InstructorID = id.Value;
				Instructor instructor = InstructorData.Instructors
					.Where(i => i.ID == id.Value).Single();
				InstructorData.Courses = instructor.Courses;
			}

			if (courseID != null)
			{
				CourseID = courseID.Value;
				IEnumerable<Enrollment> Enrollments = await _context.Enrollments
					.Where(x => x.CourseID == CourseID)
					.Include(i => i.Student)
					.ToListAsync();
				InstructorData.Enrollments = Enrollments;
			}
		}
    }
}
