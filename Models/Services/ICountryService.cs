using People_MVC_assignment_Lexicon.Models.Basemodels;

namespace People_MVC_assignment_Lexicon.Models.Services
{
    public interface ICountryService
    {
        Country Create();
        List<Country> GetAll();
        Country FindById(int id);
        List<Country> FindByName(string name);
        List<Country> FindByCountry(string city);
        List<Country> GetByAny(string search);
        bool Edit(int id);
        bool Remove(int id);
    }
}
