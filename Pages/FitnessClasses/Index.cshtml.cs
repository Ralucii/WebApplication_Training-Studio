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
    public class IndexModel : PageModel
    {
        private readonly WebApplication_Training_Studio.Data.WebApplication_Training_StudioContext _context;

        public IndexModel(WebApplication_Training_Studio.Data.WebApplication_Training_StudioContext context)
        {
            _context = context;
        }

        public IList<FitnessClass> FitnessClass { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.FitnessClass != null)
            {
                FitnessClass = await _context.FitnessClass.Include(b => b.Trainer).ToListAsync();
                FitnessClass = await _context.FitnessClass.Include(b => b.Location).ToListAsync();
            }
        }
    }
}
