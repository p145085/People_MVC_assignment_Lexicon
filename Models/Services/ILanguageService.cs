using People_MVC_assignment_Lexicon.Models.Basemodels;

namespace People_MVC_assignment_Lexicon.Models.Services
{
    public interface ILanguageService
    {
        Language Create();
        List<Language> GetAll();
        Language FindById(int id);
        List<Language> FindByName(string name);
        List<Language> FindByLanguage(string language);
        List<Language> GetByAny(string search);
        bool Edit(int id);
        bool Remove(int id);
    }
}
