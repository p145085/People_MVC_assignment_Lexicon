using Microsoft.AspNetCore.Mvc;
using People_MVC_assignment_Lexicon.Models.Basemodels;
using People_MVC_assignment_Lexicon.Models.Services;
using People_MVC_assignment_Lexicon.Models.ViewModels;

namespace People_MVC_assignment_Lexicon.Controllers
{
    public class LanguagesController : Controller
    {
        ILanguageService _languageService;

        public LanguagesController(ILanguageService languageService)
        {
            _languageService = languageService;
        }

        [HttpGet]
        public IActionResult ViewLanguages()
        {
            List<Language> all = _languageService.GetAll();
            return View(all);
        }

        [HttpGet]
        public IActionResult LanguageDetails(int id)
        {
            Language language = _languageService.FindById(id);
            if (language == null)
            {
                return RedirectToAction(nameof(ViewLanguages));
            }
            if (language.LanguageId == id)
            {
                return View(language);
            }
            return View();
        }

        [HttpGet]
        public IActionResult LanguageSearchByName(string search)
        {
            List<Language> result = _languageService.FindByName(search);
            if (result == null)
            {
                return RedirectToAction(nameof(ViewLanguages));
            }
            if (result != null)
            {
                foreach (Language language in result)
                {
                    if (language.Name == search)
                    {
                        return View(language);
                    }
                }
                return View(result);
            }
            return View();
        }

        [HttpGet]
        public IActionResult LanguageSearch(string search)
        {
            List<Language> result = _languageService.GetByAny(search);
            if (result == null)
            {
                return RedirectToAction(nameof(ViewLanguages));
            }
            if (result != null)
            {
                foreach (Language language in result)
                {
                    if (language.Name == search)
                    {
                        return View(language);
                    }
                }
                return View(result);
            }
            return View();
        }

        //[HttpGet]
        //public IActionResult CountrySearchByCity(string search)
        //{
        //    List<Name> result = _countryService.GetByAny(search);
        //    if (result == null)
        //    {
        //        return RedirectToAction(nameof(ViewCountries));
        //    }
        //    if (result != null)
        //    {
        //        foreach (Name country in result)
        //        {
        //            if (country.CityNameFromViewModel.Name == search)
        //            {
        //                return View(person);
        //            }
        //        }
        //        return View(result);
        //    }
        //    return View();
        //}

        [HttpGet]
        public IActionResult NewLanguage()
        {
            return View(new CreateLanguageViewModel());
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult NewLanguage(CreateLanguageViewModel clvm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _languageService.Create(clvm);
                }
                catch (ArgumentException exception)
                {
                    ModelState.AddModelError("error", exception.Message);
                    return View(clvm);
                }
                return RedirectToAction(nameof(ViewLanguages));
            }
            return View(clvm);
        }

        [HttpGet]
        public IActionResult DeleteLanguage(int delete)
        {
            _languageService.Remove(delete);
            return RedirectToAction(nameof(ViewLanguages));
        }
    }
}
