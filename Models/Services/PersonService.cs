using People_MVC_assignment_Lexicon.Models.Repos;
using People_MVC_assignment_Lexicon.Models.ViewModels;
using System;
using System.Xml.Linq;

namespace People_MVC_assignment_Lexicon.Models.Services
{
    public class PersonService : IPersonService
    {
        IPersonRepo _personRepo;
        public PersonService(IPersonRepo personRepo)
        {
            _personRepo = personRepo;
        }
        public Person Create(CreatePersonViewModel createPerson)
        {
            if (string.IsNullOrWhiteSpace(createPerson.FirstName) ||
                string.IsNullOrWhiteSpace(createPerson.LastName) //||
                //string.IsNullOrWhiteSpace(createPerson.FullName))
                )
            { 
                throw new ArgumentException("No whitespace allowed."); 
            }

            Person person = new Person()
            {
                Id = createPerson.Id,
                FirstName = createPerson.FirstName,
                LastName = createPerson.LastName,
                City = createPerson.City,
                Age = createPerson.Age,
                FullName = createPerson.FullName,
            };
            person = _personRepo.Create(person);
            return person;
        }

        public Person FindById(int id)
        {
            return _personRepo.GetById(id);
        }
        public Person FindByName(string name)
        {
            return _personRepo.GetByName(name);
        }
        public Person FindByCity(string city)
        {
            return _personRepo.GetByCity(city);
        }
        public List<Person> GetAll()
        {
            return _personRepo.GetAll();
        }

        public bool Edit(int id, CreatePersonViewModel person)
        {
            foreach (Person p in InMemoryPersonRepo.personList)
                if (id == p.Id)
                {
                    p.FirstName = person.FirstName;
                    p.City = person.City;
                    p.Age = person.Age;
                    p.LastName = person.LastName;
                    return true;
                }
            return false;
        }

        public bool Remove(int id)
        {
            foreach (Person p in InMemoryPersonRepo.personList)
                if (id == p.Id)
                {
                    InMemoryPersonRepo.personList.Remove(p);
                    return true;
                }
            return false;
        }
    }
}
