using Microsoft.AspNetCore.Mvc;
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

        public IActionResult Delete(int id)
        {
            _peopleService.Remove(id);
            return RedirectToAction(nameof(ViewPeople));
        }
    }
}
