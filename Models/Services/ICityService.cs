using People_MVC_assignment_Lexicon.Models.Basemodels;
using People_MVC_assignment_Lexicon.Models.ViewModels;

namespace People_MVC_assignment_Lexicon.Models.Services
{
    public interface ICityService
    {
        City Create(CreateCityViewModel createCityViewModel);
        List<City> GetAll();
        City FindById(int id);
        List<City> FindByCity(string city);
        List<City> GetByAny(string search);
        bool Edit(int id, CreateCityViewModel createCityViewModel);
        bool Remove(int id);
    }
}
