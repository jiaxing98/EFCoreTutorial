﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EFCoreTutorial.Data;
using EFCoreTutorial.Models;

namespace EFCoreTutorial.Pages.Departments
{
    public class IndexModel : PageModel
    {
        private readonly EFCoreTutorial.Data.SchoolContext _context;

        public IndexModel(EFCoreTutorial.Data.SchoolContext context)
        {
            _context = context;
        }

        public IList<Department> Department { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Departments != null)
            {
                Department = await _context.Departments
                .Include(d => d.Administrator).ToListAsync();
            }
        }
    }
}
