using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication_Training_Studio.Data;
using WebApplication_Training_Studio.Models;

namespace WebApplication_Training_Studio.Pages.FitnessClasses
{
    public class CreateModel : PageModel
    {
        private readonly WebApplication_Training_Studio.Data.WebApplication_Training_StudioContext _context;

        public CreateModel(WebApplication_Training_Studio.Data.WebApplication_Training_StudioContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["TrainerID"] = new SelectList(_context.Set<Trainer>(), "ID", "LastName");
            ViewData["LocationID"] = new SelectList(_context.Set<Location>(), "ID", "Name");
            return Page();
        }

        [BindProperty]
        public FitnessClass FitnessClass { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.FitnessClass.Add(FitnessClass);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
