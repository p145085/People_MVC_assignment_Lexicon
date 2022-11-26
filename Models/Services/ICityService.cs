using People_MVC_assignment_Lexicon.Models.Basemodels;
using People_MVC_assignment_Lexicon.Models.ViewModels;

namespace People_MVC_assignment_Lexicon.Models.Services
{
    public interface ICityService
    {
        City Create();
        List<City> GetAll();
        City FindById(int id);
        List<City> FindByName(string name);
        List<City> FindByCity(string city);
        List<City> GetByAny(string search);
        bool Edit(int id);
        bool Remove(int id);
    }
}
