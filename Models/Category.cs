namespace WebApplication_Training_Studio.Models
{
    public class Category
    {
        public int ID { get; set; }
        public string CategoryName { get; set; }

        public ICollection<FitnessClassCategory>? FitnessClassCategories { get; set; }
    }
}
