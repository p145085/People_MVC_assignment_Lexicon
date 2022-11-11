using System.ComponentModel.DataAnnotations;

namespace People_MVC_assignment_Lexicon.Models.ViewModels
{
    public class CreatePersonViewModel
    {
        [Display(Name = "a Person")]
        [Required]
        public string? FirstName { get; set; }
        [Display(Name = "of Excellence")]
        [Required]
        public string? LastName { get; set; }

        public string? FullName { get { return FullName = FirstName + LastName; } set { } }
        public int Id { get; set; }
        public int Age { get; set; }
        public string? City { get; set; }
        public long Phone { get; set; }

        public CreatePersonViewModel()
        {
            FullName = FirstName + " " + LastName;
        }

    }
}
