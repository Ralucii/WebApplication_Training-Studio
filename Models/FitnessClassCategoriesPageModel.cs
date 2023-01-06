using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication_Training_Studio.Data;

namespace WebApplication_Training_Studio.Models
{
    public class FitnessClassCategoriesPageModel : PageModel
    {
        public List<AssignedCategoryData> AssignedCategoryDataList;

        public void PopulateAssignedCategoryData(WebApplication_Training_StudioContext context,
            FitnessClass fitnessClass)

        {

            var allCategories = context.Category;
            var fitnessClassCategories = new HashSet<int>(

            fitnessClass.FitnessClassCategories.Select(c => c.CategoryID));

            AssignedCategoryDataList = new List<AssignedCategoryData>();

            foreach (var cat in allCategories)
            {
                AssignedCategoryDataList.Add(new AssignedCategoryData
                {
                    CategoryID = cat.ID,
                    Name = cat.CategoryName,
                    Assigned = fitnessClassCategories.Contains(cat.ID)
                });
            }
        }
        public void UpdateFitnessClassCategories(WebApplication_Training_StudioContext context,
            string[] selectedCategories, FitnessClass fitnessClassToUpdate)

        {

            if (selectedCategories == null)
            {
                fitnessClassToUpdate.FitnessClassCategories = new List<FitnessClassCategory>();
                return;
            }

            var selectedCategoriesHS = new HashSet<string>(selectedCategories);
            var fitnessClassCategories = new HashSet<int>
            (fitnessClassToUpdate.FitnessClassCategories.Select(c => c.Category.ID));

            foreach (var cat in context.Category)
            {
                if (selectedCategoriesHS.Contains(cat.ID.ToString()))
                    {

                    if (!fitnessClassCategories.Contains(cat.ID))
                    {
                        fitnessClassToUpdate.FitnessClassCategories.Add(
                        new FitnessClassCategory
                        {
                            FitnessClassID = fitnessClassToUpdate.ID,
                            CategoryID = cat.ID
                        });
                    }
                }

                else
                {
                    if (fitnessClassCategories.Contains(cat.ID))
                    {

                        FitnessClassCategory courseToRemove = fitnessClassToUpdate.FitnessClassCategories
                            .SingleOrDefault(i => i.CategoryID == cat.ID);
                        context.Remove(courseToRemove);

                    }
                }
            }
        }
    }
}
