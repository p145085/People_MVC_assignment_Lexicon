using Microsoft.AspNetCore.Mvc;
using People_MVC_assignment_Lexicon.Models.Basemodels;
using People_MVC_assignment_Lexicon.Models.Repos;
using People_MVC_assignment_Lexicon.Models.Services;
using People_MVC_assignment_Lexicon.Models.ViewModels;

namespace People_MVC_assignment_Lexicon.Controllers
{
    public class PersonController : Controller
    {
        IPeopleService _peopleService;

        public PersonController(IPeopleService peopleService)
        {
            _peopleService = peopleService;
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
            Person person = _peopleService.FindById(id);
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
            List<Person> result = _peopleService.FindByName(search);
            if (result == null)
            {
                return RedirectToAction(nameof(ViewPeople));
            }
            if (result != null)
            {
                foreach (Person person in result)
                {
                    if (person.FirstName == search 
                        || person.LastName == search)
                    {
                        return View(person);
                        break;
                    }
                }
                return View(result);
            }
            return View();
        }

        [HttpGet]
        public IActionResult PersonSearch(string search)
        {
            List<Person> result = _peopleService.GetByAny(search);
            if (result == null)
            {
                return RedirectToAction(nameof(ViewPeople));
            }
            if (result != null)
            {
                foreach (Person person in result)
                {
                    if (person.FirstName == search
                        || person.LastName == search
                        || person.City.Name == search
                        || person.Age.ToString() == search
                        || person.Phone.ToString() == search
                        )
                    {
                        return View(person);
                        break;
                    }
                }
                return View(result);
            }
            return View();
        }

        [HttpGet]
        public IActionResult PersonSearchByCity(string search)
        {
            List<Person> result = _peopleService.FindByCity(search);
            if (result == null)
            {
                return RedirectToAction(nameof(ViewPeople));
            }
            if (result != null)
            {
                foreach (Person person in result)
                {
                    if (person.City.Name == search)
                    {
                        return View(person);
                        break;
                    }
                }
                return View(result);
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
