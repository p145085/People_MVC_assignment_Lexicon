using Microsoft.AspNetCore.Mvc;
using People_MVC_assignment_Lexicon.Models.Basemodels;
using People_MVC_assignment_Lexicon.Models.Services;
using People_MVC_assignment_Lexicon.Models.ViewModels;

namespace People_MVC_assignment_Lexicon.Controllers
{
    public class CountriesController : Controller
    {
        ICountryService _countryService;

        public CountriesController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        [HttpGet]
        public IActionResult ViewCountries()
        {
            List<Country> all = _countryService.GetAll();
            return View(all);
        }

        [HttpGet]
        public IActionResult CountryDetails(int id)
        {
            Country country = _countryService.FindById(id);
            if (country == null)
            {
                return RedirectToAction(nameof(ViewCountries));
            }
            if (country.CountryId == id)
            {
                return View(country);
            }
            return View();
        }

        [HttpGet]
        public IActionResult CountrySearchByName(string search)
        {
            List<Country> result = _countryService.FindByName(search);
            if (result == null)
            {
                return RedirectToAction(nameof(ViewCountries));
            }
            if (result != null)
            {
                foreach (Country country in result)
                {
                    if (country.Name == search)
                    {
                        return View(country);
                    }
                }
                return View(result);
            }
            return View();
        }

        [HttpGet]
        public IActionResult CountrySearch(string search)
        {
            List<Country> result = _countryService.GetByAny(search);
            if (result == null)
            {
                return RedirectToAction(nameof(ViewCountries));
            }
            if (result != null)
            {
                foreach (Country country in result)
                {
                    if (country.Name == search)
                    {
                        return View(country);
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
        public IActionResult NewCountry()
        {
            return View(new CreateCountryViewModel());
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult NewCountry(CreateCountryViewModel ccvm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _countryService.Create(ccvm);
                }
                catch (ArgumentException exception)
                {
                    ModelState.AddModelError("error", exception.Message);
                    return View(ccvm);
                }
                return RedirectToAction(nameof(ViewCountries));
            }
            return View(ccvm);
        }

        [HttpGet]
        public IActionResult DeleteCountry(int delete)
        {
            _countryService.Remove(delete);
            return RedirectToAction(nameof(ViewCountries));
        }
    }
}
