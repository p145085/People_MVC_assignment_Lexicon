using People_MVC_assignment_Lexicon.Models.Basemodels;
using People_MVC_assignment_Lexicon.Models.ViewModels;

namespace People_MVC_assignment_Lexicon.Models.Services
{
    public interface ICountryService
    {
        Country Create(CreateCountryViewModel createCountryViewModel);
        List<Country> GetAll();
        Country FindById(int id);
        List<Country> FindByName(string name);
        List<Country> FindByCountry(string city);
        List<Country> GetByAny(string search);
        bool Edit(int id, CreateCountryViewModel createCountryViewModel);
        bool Remove(int id);
    }
}
