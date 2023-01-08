using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication_Training_Studio.Data;
using WebApplication_Training_Studio.Models;


namespace WebApplication_Training_Studio.Pages.FitnessClasses
{
    [Authorize(Roles = "Admin")]

    public class CreateModel : FitnessClassCategoriesPageModel
    {
        private readonly WebApplication_Training_Studio.Data.WebApplication_Training_StudioContext _context;

        public CreateModel(WebApplication_Training_Studio.Data.WebApplication_Training_StudioContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {

            var trainerList = _context.Trainer.Select(x => new
            {
                x.ID,
                FullName = x.LastName + " " + x.FirstName
            });

            ViewData["TrainerID"] = new SelectList(trainerList, "ID", "FullName");
            ViewData["LocationID"] = new SelectList(_context.Set<Location>(), "ID", "Name");

            var fitnessClass = new FitnessClass();
            fitnessClass.FitnessClassCategories = new List<FitnessClassCategory>();
            PopulateAssignedCategoryData(_context, fitnessClass);


            return Page();
        }

        [BindProperty]
        public FitnessClass FitnessClass { get; set; }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {

            var newFitnessClass = new FitnessClass();
            if (selectedCategories != null)

            {

                newFitnessClass.FitnessClassCategories = new List<FitnessClassCategory>();
                foreach (var cat in selectedCategories)
                {
                    var catToAdd = new FitnessClassCategory
                    {
                        CategoryID = int.Parse(cat)
                    };
                    newFitnessClass.FitnessClassCategories.Add(catToAdd);

                }



                _context.FitnessClass.Add(FitnessClass);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            PopulateAssignedCategoryData(_context, newFitnessClass);
            return Page();
        }
    }
}
