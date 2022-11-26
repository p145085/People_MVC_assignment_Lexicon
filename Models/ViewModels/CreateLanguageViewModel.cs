namespace People_MVC_assignment_Lexicon.Models.ViewModels
{
    public class CreateLanguageViewModel
    {
        public int Id { get; set; }
        public string? Language { get; set; }

        public List<string> PeopleList
        {
            get
            {
                return new List<string>
                { "Boris Johnson", "Theresa May", "Winston Churchill"
                };
            }
        }
    }
}
