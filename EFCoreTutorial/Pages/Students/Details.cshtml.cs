using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EFCoreTutorial.Data;
using EFCoreTutorial.Models;

namespace EFCoreTutorial.Pages.Students
{
	public class DetailsModel : PageModel
	{
		private readonly EFCoreTutorial.Data.SchoolContext _context;

		public DetailsModel(EFCoreTutorial.Data.SchoolContext context)
		{
			_context = context;
		}

		public Student Student { get; set; }

		public async Task<IActionResult> OnGetAsync(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			Student = await _context.People.OfType<Student>()
				.Include(s => s.Enrollments)
				.ThenInclude(e => e.Course)
				.AsNoTracking()
				.FirstOrDefaultAsync(m => m.ID == id);

			var student = await _context.People.OfType<Student>()
				.FirstOrDefaultAsync(m => m.ID == id);
			if (student == null)
			{
				return NotFound();
			}
			else
			{
				Student = student;
			}
			return Page();
		}
	}
}
