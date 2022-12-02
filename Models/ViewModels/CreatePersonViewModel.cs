using System.ComponentModel.DataAnnotations;

namespace People_MVC_assignment_Lexicon.Models.ViewModels
{
    public class CreatePersonViewModel
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? FullName { get { return FullName = FirstName + LastName; } set { } }
        public int Id { get; set; }
        public int Age { get; set; }
        public string? City { get; set; }
        public string? Phone { get; set; }

        public CreatePersonViewModel()
        {
            FullName = FirstName + " " + LastName;
        }
    }
}
