using People_MVC_assignment_Lexicon.Models.Basemodels;
using System.ComponentModel.DataAnnotations;

namespace People_MVC_assignment_Lexicon.Models.ViewModels
{
    public class CreatePersonViewModel
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int Id { get; set; }
        public int Age { get; set; }
        public int CityId { get; set; }
        public string? CityNameFromViewModel { get; set; }
        public string? Phone { get; set; }
    }
}
