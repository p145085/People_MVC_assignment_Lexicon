namespace People_MVC_assignment_Lexicon.Models.ViewModels
{
    public class CreateCityViewModel
    {
            public int Id { get; set; }
            public string? City { get; set; }

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
