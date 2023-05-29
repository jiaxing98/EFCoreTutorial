using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EFCoreTutorial.Data;
using EFCoreTutorial.Models;

namespace EFCoreTutorial.Pages.Departments
{
	public class CreateModel : PageModel
	{
		private readonly SchoolContext _context;

		public CreateModel(SchoolContext context)
		{
			_context = context;
		}

		public IActionResult OnGet()
		{
			var instructors = _context.People.OfType<Instructor>().ToList();
			ViewData["InstructorID"] = new SelectList(instructors, "ID", "FirstMidName");
			return Page();
		}

		[BindProperty]
		public Department Department { get; set; }


		// To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
		public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid)
			{
				return Page();
			}

			_context.Departments.Add(Department);
			await _context.SaveChangesAsync();

			return RedirectToPage("./Index");
		}
	}
}
