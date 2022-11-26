using People_MVC_assignment_Lexicon.Models.Basemodels;

namespace People_MVC_assignment_Lexicon.Models.Repos
{
    public interface ICountryRepo
    {
        Country Create(Country country);
        List<Country> GetAll();
        Country GetById(int id);
        List<Country> GetByName(string name);
        List<Country> GetByCountry(string country);
        void Update(Country country);
        void Delete(Country country);
    }
}
