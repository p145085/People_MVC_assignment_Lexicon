using People_MVC_assignment_Lexicon.Models.Basemodels;
using People_MVC_assignment_Lexicon.Models.ViewModels;

namespace People_MVC_assignment_Lexicon.Models.Services
{
    public interface ILanguageService
    {
        Language Create(CreateLanguageViewModel createLanguageViewModel);
        List<Language> GetAll();
        Language FindById(int id);
        List<Language> FindByName(string name);
        List<Language> FindByLanguage(string language);
        List<Language> GetByAny(string search);
        bool Edit(int id, CreateLanguageViewModel createLanguageViewModel);
        bool Remove(int id);
    }
}
