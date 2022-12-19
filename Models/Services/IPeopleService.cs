using People_MVC_assignment_Lexicon.Models.Basemodels;
using People_MVC_assignment_Lexicon.Models.ViewModels;

namespace People_MVC_assignment_Lexicon.Models.Services
{
    public interface IPeopleService
    {
        Person? Create(CreatePersonViewModel createPerson);
        List<Person>? GetAll();
        List<Person>? GetById(int id);
        List<Person>? GetByName(string search);
        List<Person>? GetByCity(string search);
        List<Person>? GetByAny(string search);
        bool Edit(int id, CreatePersonViewModel editPerson);
        bool Remove(int id);
    }
}
