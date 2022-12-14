namespace People_MVC_assignment_Lexicon.Models.Basemodels
{
    public class Language
    {
        public int LanguageId { get; set; }
        public string? Name { get; set; }
        public List<Person>? People { get; set; }
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