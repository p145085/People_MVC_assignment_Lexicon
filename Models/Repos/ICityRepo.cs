using People_MVC_assignment_Lexicon.Models.Basemodels;

namespace People_MVC_assignment_Lexicon.Models.Repos
{
    public interface ICityRepo
    {
        City Create(City city);
        List<City> GetAll();
        City GetById(int id);
        City GetByCityName(string name);
        //List<City> GetByCityName(string city);
        //List<City> GetByAny(string search);
        void Update(City city);
        void Delete(City city);
    }
}
