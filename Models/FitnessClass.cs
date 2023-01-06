using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace WebApplication_Training_Studio.Models
{
    public class FitnessClass
    {
        public int ID { get; set; }


        [Display(Name = "Name of the class")]
        public string Name { get; set; }  
        
        public string Description { get; set; }

        [Column(TypeName = "decimal(6, 2)")]

        public decimal Price { get; set; }

        public string Duration  { get; set; }

        public int? TrainerID { get; set; }

        public int? LocationID { get; set; }

        public Trainer? Trainer  { get; set; }
        
        public Location? Location { get; set; }

        public ICollection <FitnessClassCategory>? FitnessClassCategories  { get; set; }

    }
}
