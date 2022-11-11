using People_MVC_assignment_Lexicon.Models.Repos;
using People_MVC_assignment_Lexicon.Models.ViewModels;
using System;

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
            if (string.IsNullOrWhiteSpace(createPerson.firstName) ||
                string.IsNullOrWhiteSpace(createPerson.lastName) ||
                string.IsNullOrWhiteSpace(createPerson.fullName))
            { 
                throw new ArgumentException("No whitespace allowed."); 
            }

            Person person = new Person()
            {
                firstName = createPerson.firstName,
                lastName = createPerson.lastName,
            };
            person = _personRepo.Create(person);
            return person;
        }

        public Person FindById(int id)
        {
            return _personRepo.GetById(id);
        }
        public List<Person> GetAll()
        {
            return _personRepo.GetAll();
        }

        public bool Edit(int id, CreatePersonViewModel person)
        {
            foreach (Person p in InMemoryPeopleRepo.personList)
                if (id == p.id)
                {
                    p.firstName = person.firstName;
                    p.city = person.city;
                    p.age = person.age;
                    p.lastName = person.lastName;
                    return true;
                }
            return false;
        }

        public bool Remove(int id)
        {
            foreach (Person p in InMemoryPeopleRepo.personList)
                if (id == p.id)
                {
                    InMemoryPeopleRepo.personList.Remove(p);
                    return true;
                }
            return false;
        }

        public Person FindByName(string name)
        {
            throw new NotImplementedException();
        }

        public Person FindByCity(string city)
        {
            throw new NotImplementedException();
        }
    }
}
