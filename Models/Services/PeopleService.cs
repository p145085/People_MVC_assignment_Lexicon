using People_MVC_assignment_Lexicon.Models.Basemodels;
using People_MVC_assignment_Lexicon.Models.Repos;
using People_MVC_assignment_Lexicon.Models.ViewModels;
using System;
using System.Xml.Linq;

namespace People_MVC_assignment_Lexicon.Models.Services
{
    public class PeopleService : IPeopleService
    {
        IPeopleRepo _personRepo;
        public PeopleService(IPeopleRepo personRepo)
        {
            _personRepo = personRepo;
        }

        public Person Create(CreatePersonViewModel createPerson)
        {
            if (string.IsNullOrWhiteSpace(createPerson.FirstName) ||
                string.IsNullOrWhiteSpace(createPerson.LastName)
                )
            { 
                throw new ArgumentException("No whitespace allowed."); 
            }

            Person person = new Person()
            {
                Id = createPerson.Id,
                FirstName = createPerson.FirstName,
                LastName = createPerson.LastName,
                Age = createPerson.Age,
                FullName = createPerson.FullName,
                Phone = createPerson.Phone,
            };
            person = _personRepo.Create(person);
            return person;
        }

        public Person FindById(int id)
        {
            return _personRepo.GetById(id);
        }
        public List<Person> FindByName(string name)
        {
            return _personRepo.GetByName(name);
        }
        public List<Person> FindByCity(string city)
        {
            return _personRepo.GetByCity(city);
        }
        public List<Person> GetAll()
        {
            return _personRepo.GetAll();
        }
        public List<Person> GetByAny(string search)
        {
            List<Person> thePeople = _personRepo.GetAll();
            List<Person> theFoundPeople = new List<Person>();

            if (search != null)
            {
                foreach (Person person in thePeople)
                {
                    if (
                        search == person.FirstName || search == person.FirstName || search == person.LastName
                        )
                    {
                        theFoundPeople.Add(person);
                    }
                }
                return theFoundPeople;
            }
            else
            {
                return null;
            }
        }

        public bool Edit(int id, CreatePersonViewModel person)
        {
            foreach (Person p in _personRepo.GetAll())
                if (id == p.Id)
                {
                    p.FirstName = person.FirstName;
                    p.Age = person.Age;
                    p.LastName = person.LastName;
                    return true;
                }
            return false;
        }

        public bool Remove(int id)
        {
            foreach (Person p in _personRepo.GetAll())
                if (id == p.Id)
                {
                    _personRepo.GetAll().Remove(p);
                    return true;
                }
            return false;
        }
    }
}
