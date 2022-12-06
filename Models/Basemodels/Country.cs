namespace People_MVC_assignment_Lexicon.Models.Basemodels
{
    public class Country
    {
        public int CountryId { get; set; }
        public string? Name { get; set; }
        public List<City>? Cities { get; set; }
        public List<string> CountryList
        {
            get
            {
                return new List<string>

            { "Sverige", "England", "USA", "Island", "Ryssland", "Japan" };
            }
        }
        public List<string> CityList
        {
            get
            {
                return new List<string>

                { "Kalmar", "Malmö", "Göteborg", "Stockholm", "Växjö", "Uppsala" };
            }
        }
    }
}