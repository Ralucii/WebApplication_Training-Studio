using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

        public IList<FitnessClass> FitnessClass { get; set; } = default!;
        public FitnessClassData FitnessClassD { get; set; }
        public int FitnessClassID { get; set; }
        public int CategoryID { get; set; }

        //Proprietatile pentru sortare 
        public string ClassNameSort { get; set; }
        public string TrainerSort { get; set; }
        //sortam dupa numele clasei si cel al trainerului

        public string CurrentFilter { get; set; }

        public async Task OnGetAsync(int? id, int? categoryID, string sortOrder, string searchString)
        {
            FitnessClassD = new FitnessClassData();

            ClassNameSort = String.IsNullOrEmpty(sortOrder) ? "classname_desc" : "";
            TrainerSort = String.IsNullOrEmpty(sortOrder) ? "trainer_desc" : "";

            CurrentFilter = searchString;

            FitnessClassD.FitnessClasses = await _context.FitnessClass
             .Include(b => b.Location)
             .Include(b => b.Trainer)
             .Include(b => b.FitnessClassCategories)
             .ThenInclude(b => b.Category)
             .AsNoTracking()
             .OrderBy(b => b.Name)
             .ToListAsync();

            if (!String.IsNullOrEmpty(searchString))
            {
                FitnessClassD.FitnessClasses = FitnessClassD.FitnessClasses
                    .Where(s => s.Trainer.LastName.Contains(searchString)
                    || s.Trainer.FirstName.Contains(searchString)
                    || s.Name.Contains(searchString));
            }

            if (id != null)
            {
                FitnessClassID = id.Value;
                FitnessClass fitnessClass = FitnessClassD.FitnessClasses
                .Where(i => i.ID == id.Value).Single();
                FitnessClassD.Categories = fitnessClass.FitnessClassCategories.Select(s => s.Category);
            }
            switch (sortOrder)
            {
                case "classname_desc":
                    FitnessClassD.FitnessClasses = FitnessClassD.FitnessClasses.OrderByDescending(s => s.Name);
                    break;
                case "trainer_desc":
                    FitnessClassD.FitnessClasses = FitnessClassD.FitnessClasses.OrderByDescending(s => s.Trainer.LastName);
                    break;
            }
        }
    }
}