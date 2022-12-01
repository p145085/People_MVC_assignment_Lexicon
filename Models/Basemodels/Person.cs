namespace People_MVC_assignment_Lexicon.Models.Basemodels
{
    public class Person
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? FullName { get; set; }
        public int Age { get; set; }
        public City? City { get; set; }
        public long Phone { get; set; }
        public List<Language> Languages { get; set; }
    }
}
