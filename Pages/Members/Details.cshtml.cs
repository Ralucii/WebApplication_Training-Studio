using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication_Training_Studio.Data;
using WebApplication_Training_Studio.Models;

namespace WebApplication_Training_Studio.Pages.Members
{
    public class DetailsModel : PageModel
    {
        private readonly WebApplication_Training_Studio.Data.WebApplication_Training_StudioContext _context;

        public DetailsModel(WebApplication_Training_Studio.Data.WebApplication_Training_StudioContext context)
        {
            _context = context;
        }

      public Member Member { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Member == null)
            {
                return NotFound();
            }

            var member = await _context.Member.FirstOrDefaultAsync(m => m.ID == id);
            if (member == null)
            {
                return NotFound();
            }
            else 
            {
                Member = member;
            }
            return Page();
        }
    }
}
