using People_MVC_assignment_Lexicon.Models.Basemodels;
using People_MVC_assignment_Lexicon.Models.Repos;
using People_MVC_assignment_Lexicon.Models.ViewModels;
using System;
using System.Linq;
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

        public Person GetById(int id)
        {
            return _personRepo.GetById(id);
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
                        search == person.Id.ToString()
                        || search == person.FirstName
                        || search == person.LastName
                        || search == person.FullName
                        || search == person.Age.ToString()
                        || search == person.City.ToString()
                        || search == person.Phone.ToString()
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
            foreach (Person temp in _personRepo.GetAll())
                if (temp.Id == id)
                {
                    temp.FirstName = person.FirstName;
                    temp.LastName = person.LastName;
                    temp.FullName = person.FullName;
                    temp.Age = person.Age;
                    temp.Phone = person.Phone;
                    return true;
                }
            return false;
        }

        public bool Remove(int id)
        {
            foreach (Person temp in _personRepo.GetAll())
                if (id == temp.Id)
                {
                    _personRepo.GetAll().Remove(temp);
                    return true;
                }
            return false;
        }
    }
}
