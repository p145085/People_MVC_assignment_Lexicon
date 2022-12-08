using System.ComponentModel.DataAnnotations.Schema;

namespace People_MVC_assignment_Lexicon.Models.Basemodels
{
    public class Person
    {
        public int PersonId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int Age { get; set; }
        public string? Phone { get; set; }
        public int CityIdFromPerson { get; set; }
        public City? CityFromPerson { get; set; }
        public List<Language>? Languages { get; set; }
    }
}
