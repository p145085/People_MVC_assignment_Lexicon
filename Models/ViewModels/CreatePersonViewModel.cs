using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace People_MVC_assignment_Lexicon.Models.ViewModels
{
    public class CreatePersonViewModel
    {
        [Display(Name = "a Person")]
        [Required]
        public string? firstName { get; set; }
        [Display(Name = "of Excellence")]
        [Required]
        public string? lastName { get; set; }

        public string? fullName { get; set; }
        public int id { get; set; }
        public int age { get; set; }
        public string? city { get; set; }
        public long phone { get; set; }

        public CreatePersonViewModel()
        {
            fullName = firstName + " " + lastName;
        }

    }
}
