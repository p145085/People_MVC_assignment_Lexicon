using System.ComponentModel.DataAnnotations.Schema;

namespace People_MVC_assignment_Lexicon.Models.Basemodels
{
    public class City
    {
        public int CityId { get; set; }
        public string? Name { get; set; }
        public List<Person>? People { get; set; }
        public int CountryIdFromPerson { get; set; }
        public Country? Country { get; set; }

        public List<string> PeopleList
        {
            get
            {
                return new List<string>
                { "Astrid Lindgren", "Bo Kasper", "Carl Einar Häckner", "Amelia Andersdotter", "Robert Gustafsson", "Carl Gustav"
                };
            }
        }
    }
}