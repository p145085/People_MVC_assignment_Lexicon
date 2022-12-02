using People_MVC_assignment_Lexicon.Models.Basemodels;

namespace People_MVC_assignment_Lexicon.Models.Repos
{
    public interface ILanguageRepo
    {
        Language Create(Language language);
        List<Language> GetAll();
        Language GetById(int id);
        List<Language> GetByName(string name);
        List<Language> GetByLanguage(string language);
        List<Language> GetByAny(string search);
        void Update(Language language);
        void Delete(Language language);
    }
}
