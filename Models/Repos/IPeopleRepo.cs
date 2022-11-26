using Microsoft.EntityFrameworkCore;
using People_MVC_assignment_Lexicon.Models.Basemodels;

namespace People_MVC_assignment_Lexicon.Models.Repos
{
    public interface IPeopleRepo
    {
        Person Create(Person person);
        List<Person> GetAll();
        Person GetById(int id);
        List<Person> GetByName(string name);
        List<Person> GetByCity(string city);
        void Update(Person person);
        void Delete(Person person);
    }
}
