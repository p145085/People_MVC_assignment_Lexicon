using People_MVC_assignment_Lexicon.Models.Basemodels;
using People_MVC_assignment_Lexicon.Models.ViewModels;

namespace People_MVC_assignment_Lexicon.Models.Services
{
    public interface IPeopleService
    {
        Person Create(CreatePersonViewModel createPerson);
        List<Person> GetAll();
        Person GetById(int id);
        List<Person> GetByName(string name);
        List<Person> GetByAny(string search);
        bool Edit(int id, CreatePersonViewModel editPerson);
        bool Remove(int id);
    }
}
