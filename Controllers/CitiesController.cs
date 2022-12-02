﻿using Microsoft.AspNetCore.Mvc;
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
            if (city.Id == id)
            {
                return View(city);
            }
            return View();
        }

        [HttpGet]
        public IActionResult CitySearchByName(string search)
        {
            List<City> result = _citiesService.FindByCity(search);
            if (result == null)
            {
                return RedirectToAction(nameof(ViewCities));
            }
            if (result != null)
            {
                foreach (City city in result)
                {
                    if (city.Name == search)
                    {
                        return View(city);
                    }
                }
                return View(result);
            }
            return View();
        }

        [HttpGet]
        public IActionResult CitySearch(string search)
        {
            List<City> result = _citiesService.GetByAny(search);
            if (result == null)
            {
                return RedirectToAction(nameof(ViewCities));
            }
            if (result != null)
            {
                foreach (City city in result)
                {
                    if (city.Name == search)
                    {
                        return View(city);
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
        //            if (country.City.Name == search)
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
        public IActionResult NewCity(CreateCityViewModel city)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _citiesService.Create(city);
                }
                catch (ArgumentException exception)
                {
                    ModelState.AddModelError("error", exception.Message);
                    return View(city);
                }
                return RedirectToAction(nameof(ViewCities));
            }
            return View(city);
        }

        [HttpGet]
        public IActionResult DeleteCity(int delete)
        {
            _citiesService.Remove(delete);
            return RedirectToAction(nameof(ViewCities));
        }
    }
}