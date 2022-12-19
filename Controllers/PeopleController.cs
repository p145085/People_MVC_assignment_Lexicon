using Microsoft.AspNetCore.Mvc;
using People_MVC_assignment_Lexicon.Models.Basemodels;
using People_MVC_assignment_Lexicon.Models.Repos;
using People_MVC_assignment_Lexicon.Models.Services;
using People_MVC_assignment_Lexicon.Models.ViewModels;

namespace People_MVC_assignment_Lexicon.Controllers
{
    public class PeopleController : Controller
    {
        IPeopleService _peopleService;
        //private readonly ICityService _cityService;
        //ICityRepo _cityRepo;

        public PeopleController(IPeopleService peopleService/*, ICityRepo cityRepo*/)
        {
            _peopleService = peopleService;
            //_cityRepo = cityRepo;
        }

        [HttpGet]
        public IActionResult ViewPeople()
        {
            List<Person> all = _peopleService.GetAll();
            return View(all);
        }

        [HttpGet]
        public IActionResult PersonDetails(int id)
        {
            List<Person> person = _peopleService.GetById(id);
            foreach(Person p in person)
            {
                if (p == null)
                {
                    return RedirectToAction(nameof(ViewPeople));
                }
                if (p.PersonId == id)
                {
                    return View(person);
                }
            }
            return View();
        }

        [HttpGet]
        public IActionResult PersonSearch(string search) // Search By Name.
        {
            try // Try GetByName first.
            {
                List<Person> result = _peopleService.GetByName(search);
                if (result.Count == 0)
                {
                    try // Try GetById second.
                    {
                        int idTest = Int32.Parse(search);
                        List<Person> idResult = _peopleService.GetById(idTest);

                        if (idResult == null)
                        {
                            try
                            {
                                List<Person> cityResult = _peopleService.GetByCity(search);
                                if (cityResult.Count != 0)
                                {
                                    return RedirectToAction(nameof(ViewPeople));
                                }
                                if (cityResult.Count > 0)
                                {
                                    return View(cityResult);
                                }
                            } catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            return RedirectToAction(nameof(ViewPeople));
                        }
                        if (idResult != null)
                        {
                            foreach (Person p in idResult)
                            {
                                if (p.PersonId == idTest)
                                {
                                    return View(idResult);
                                }
                            }
                        }

                    } catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    return RedirectToAction(nameof(ViewPeople));
                }
                if (result.Count != 0)
                {
                    return View(result);
                }
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            return View();
        }

        //[HttpGet]
        //public IActionResult PersonSearch(string search)
        //{
        //    List<Person>? result = _peopleService.GetByName(search);
        //    if (result == null)
        //    {
        //        return RedirectToAction(nameof(ViewPeople));
        //    }
        //    if (result != null)
        //    {
        //        return View(result);
        //    }
        //    return View();
        //}

        //[HttpGet]
        //public IActionResult PersonSearchByAny(string search)
        //{
        //    List<Person> result = _peopleService.GetByAny(search);
        //    if (result == null)
        //    {
        //        return RedirectToAction(nameof(ViewPeople));
        //    }
        //    if (result != null)
        //    {
        //        return View(result);
        //    }
        //    return View();
        //}

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
                    //if (_cityRepo.GetByCityName(person.CityNameFromViewModel) == null)
                    //{
                    //    throw new ArgumentException("Create this city first.");
                    //}
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
