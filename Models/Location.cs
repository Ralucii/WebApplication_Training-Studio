using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace WebApplication_Training_Studio.Models
{
    public class Location
    {
        public int ID   { get; set; }

        [Display(Name = "Name of the location")]
        public string Name     { get; set; }

        [Display(Name = "Street address")]
        public string Address     { get; set; }

    public ICollection<FitnessClass>? FitnessClass { get; set; }
    }
}
