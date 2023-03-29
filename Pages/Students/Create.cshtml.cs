﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AspNetRazorsPageEFCore.Data;
using AspNetRazorsPageEFCore.Models;

namespace AspNetRazorsPageEFCore.Pages.Students
{
    public class CreateModel : PageModel
    {
        private readonly AspNetRazorsPageEFCore.Data.AspNetRazorsPageEFCoreContext _context;

        public CreateModel(AspNetRazorsPageEFCore.Data.AspNetRazorsPageEFCoreContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Student Student { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Student == null || Student == null)
            {
                return Page();
            }

            _context.Student.Add(Student);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}