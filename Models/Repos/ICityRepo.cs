using People_MVC_assignment_Lexicon.Models.Basemodels;

namespace People_MVC_assignment_Lexicon.Models.Repos
{
    public interface ICityRepo
    {
        City Create(City city);
        List<City> GetAll();
        City GetById(int id);
        List<City> GetByName(string name);
        List<City> GetByCity(string city);
        List<City> GetByAny(string search);
        void Update(City city);
        void Delete(City city);
    }
}
