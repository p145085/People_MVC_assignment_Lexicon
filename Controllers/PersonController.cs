﻿using Microsoft.AspNetCore.Mvc;
using People_MVC_assignment_Lexicon.Models;
using People_MVC_assignment_Lexicon.Models.Repos;
using People_MVC_assignment_Lexicon.Models.Services;
using People_MVC_assignment_Lexicon.Models.ViewModels;

namespace People_MVC_assignment_Lexicon.Controllers
{
    public class PersonController : Controller
    {
        IPersonService _peopleService;

        public PersonController()
        {
            _peopleService = new PersonService(new InMemoryPersonRepo());
        }

        [HttpGet]
        public IActionResult ViewPeople()
        {
            var all = _peopleService.GetAll();
            return View(all);
        }

        [HttpGet]
        public IActionResult PersonDetails(int id)
        {
            var person = _peopleService.FindById(id);
            if (person == null)
            {
                return RedirectToAction(nameof(ViewPeople));
            }
            if (person.Id == id)
            {
                return View(person);
            }
            return View();
        }

        [HttpGet]
        public IActionResult PersonSearchByName(string search)
        {
            var person = _peopleService.FindByName(search);
            if (person == null)
            {
                return RedirectToAction(nameof(ViewPeople));
            }
            if (person.FullName.Contains(search))
            {
                return View(person);
            }
            return View();
        }

        [HttpGet]
        public IActionResult PersonSearch(string search)
        {
            List<Person> persons = _peopleService.GetByAny(search);
            if (persons == null)
            {
                return RedirectToAction(nameof(ViewPeople));
            }
            if (persons != null)
            {
                return View(persons);
            }
            return View();
        }

        [HttpGet]
        public IActionResult PersonSearchByCity(string search)
        {
            var person = _peopleService.FindByCity(search);
            if (person == null)
            {
                return RedirectToAction(nameof(ViewPeople));
            }
            if (person.City.Contains(search))
            {
                return View(person);
            }
            return View();
        }

        [HttpGet]
        public IActionResult NewPerson()
        {
            return View(new CreatePersonViewModel());
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult NewPerson(CreatePersonViewModel person)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _peopleService.Create(person);
                }
                catch (ArgumentException exception)
                {
                    ModelState.AddModelError("error", exception.Message);
                    return View(person);
                }
                return RedirectToAction(nameof(ViewPeople));
            }
            return View(person);
        }

        [HttpGet]
        public IActionResult DeletePerson(int delete)
        {
            _peopleService.Remove(delete);
            return RedirectToAction(nameof(ViewPeople));
        }
    }
}
