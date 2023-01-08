using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication_Training_Studio.Data;
using WebApplication_Training_Studio.Models;

namespace WebApplication_Training_Studio.Pages.Subscriptions
{
    public class DetailsModel : PageModel
    {
        private readonly WebApplication_Training_Studio.Data.WebApplication_Training_StudioContext _context;

        public DetailsModel(WebApplication_Training_Studio.Data.WebApplication_Training_StudioContext context)
        {
            _context = context;
        }

      public Subscription Subscription { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Subscription == null)
            {
                return NotFound();
            }

            var subscription = await _context.Subscription.FirstOrDefaultAsync(m => m.ID == id);
            if (subscription == null)
            {
                return NotFound();
            }
            else 
            {
                Subscription = subscription;
            }
            return Page();
        }
    }
}
