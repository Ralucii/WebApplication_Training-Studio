using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication_Training_Studio.Data;
using WebApplication_Training_Studio.Models;

namespace WebApplication_Training_Studio.Pages.FitnessClasses
{
    public class DeleteModel : PageModel
    {
        private readonly WebApplication_Training_Studio.Data.WebApplication_Training_StudioContext _context;

        public DeleteModel(WebApplication_Training_Studio.Data.WebApplication_Training_StudioContext context)
        {
            _context = context;
        }

        [BindProperty]
      public FitnessClass FitnessClass { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.FitnessClass == null)
            {
                return NotFound();
            }

            var fitnessclass = await _context.FitnessClass.FirstOrDefaultAsync(m => m.ID == id);

            if (fitnessclass == null)
            {
                return NotFound();
            }
            else 
            {
                FitnessClass = fitnessclass;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.FitnessClass == null)
            {
                return NotFound();
            }
            var fitnessclass = await _context.FitnessClass.FindAsync(id);

            if (fitnessclass != null)
            {
                FitnessClass = fitnessclass;
                _context.FitnessClass.Remove(FitnessClass);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
