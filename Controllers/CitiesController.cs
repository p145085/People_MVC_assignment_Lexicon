using Microsoft.AspNetCore.Mvc;
using People_MVC_assignment_Lexicon.Models.Basemodels;
using People_MVC_assignment_Lexicon.Models.Services;
using People_MVC_assignment_Lexicon.Models.ViewModels;

namespace People_MVC_assignment_Lexicon.Controllers
{
    public class CitiesController : Controller
    {
        ICityService _citiesService;

        public CitiesController(ICityService cityService)
        {
            _citiesService = cityService;
        }

        [HttpGet]
        public IActionResult ViewCities()
        {
            List<City> all = _citiesService.GetAll();
            return View(all);
        }

        [HttpGet]
        public IActionResult CityDetails(int id)
        {
            City city = _citiesService.FindById(id);
            if (city == null)
            {
                return RedirectToAction(nameof(ViewCities));
            }
            if (city.CityId == id)
            {
                return View(city);
            }
            return View();
        }

        [HttpGet]
        public IActionResult CitySearch(string search)
        {
            City result = _citiesService.GetByCity(search);
            if (result == null)
            {
                return RedirectToAction(nameof(ViewCities));
            }
            if (result != null)
            {    
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
        public IActionResult NewCity()
        {
            return View(new CreateCityViewModel());
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult NewCity(CreateCityViewModel ccvm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _citiesService.Create(ccvm);
                }
                catch (ArgumentException exception)
                {
                    ModelState.AddModelError("error", exception.Message);
                    return View(ccvm);
                }
                return RedirectToAction(nameof(ViewCities));
            }
            return View(ccvm);
        }

        [HttpGet]
        public IActionResult DeleteCity(int delete)
        {
            _citiesService.Remove(delete);
            return RedirectToAction(nameof(ViewCities));
        }
    }
}
