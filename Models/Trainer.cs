using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace WebApplication_Training_Studio.Models
{
    public class Trainer
    {

     public int ID { get; set; }

        [Display(Name = "First Name")]
        public string FirstName  { get; set; }

        [Display(Name = "Last Name")]

        public string LastName  { get; set; }

        [Display(Name = "Telephone")]
        public string PhoneNumber { get; set; }

     public string Email { get; set; }

        [Display(Name = "Personal details")]
        public string Details { get; set; }

    public ICollection<FitnessClass>? FitnessClass { get; set; }


    }

}
