using People_MVC_assignment_Lexicon.Models.Basemodels;
using People_MVC_assignment_Lexicon.Models.Repos;
using People_MVC_assignment_Lexicon.Models.ViewModels;
using System;

namespace People_MVC_assignment_Lexicon.Models.Services
{
    public class LanguageService : ILanguageService
    {
        ILanguageRepo _languageRepo;
        public LanguageService(ILanguageRepo languageRepo)
        {
            _languageRepo = languageRepo;
        }
        public Language Create(CreateLanguageViewModel createLanguageViewModel)
        {
            if (string.IsNullOrWhiteSpace(createLanguageViewModel.Language)
                )
            {
                throw new ArgumentException("No whitespace allowed.");
            }

            Language language = new Language()
            {
                Name = createLanguageViewModel.Language,
            };
            language = _languageRepo.Create(language);
            return language;
        }

        public bool Edit(int id, CreateLanguageViewModel createLanguageViewModel)
        {
            foreach (Language temp in _languageRepo.GetAll())
                if (temp.LanguageId == id)
                {
                    temp.Name = createLanguageViewModel.Language;
                    return true;
                }
            return false;
        }

        public Language FindById(int id)
        {
            return _languageRepo.GetById(id);
        }

        public List<Language> FindByLanguage(string language)
        {
            return _languageRepo.GetByLanguage(language);
        }

        public List<Language> FindByName(string name)
        {
            return _languageRepo.GetByName(name);
        }

        public List<Language> GetAll()
        {
            return _languageRepo.GetAll();
        }

        public List<Language> GetByAny(string search)
        {
            return _languageRepo.GetByAny(search);
        }

        public bool Remove(int id)
        {
            foreach (Language temp in _languageRepo.GetAll())
                if (id == temp.LanguageId)
                {
                    _languageRepo.GetAll().Remove(temp);
                    return true;
                }
            return false;
        }
    }
}
