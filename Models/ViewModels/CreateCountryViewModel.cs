namespace People_MVC_assignment_Lexicon.Models.ViewModels
{
    public class CreateCountryViewModel
    {
        public int Id { get; set; }
        public string? Country { get; set; }

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
