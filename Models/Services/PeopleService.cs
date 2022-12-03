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
                FirstName = createPerson.FirstName,
                LastName = createPerson.LastName,
                Age = createPerson.Age,
                Phone = createPerson.Phone,
            };
            _personRepo.Create(person);
            return person;
        }

        public Person GetById(int id)
        {
            return _personRepo.GetById(id);
        }
        public List<Person> GetByName(string name)
        {
            return _personRepo.GetByName(name);
        }
        public List<Person> GetAll()
        {
            return _personRepo.GetAll();
        }
        public List<Person> GetByAny(string search)
        {
            //List<Person> thePeople = _personRepo.GetAll();
            //List<Person> theFoundPeople = new List<Person>();

            //if (search != null)
            //{
            //    foreach (Person person in thePeople)
            //    {
            //        if (
            //            search == person.PersonId.ToString()
            //            || search == person.FirstName
            //            || search == person.LastName
            //            || search == person.Age.ToString()
            //            //|| search == person.City.Name.ToString()
            //            || search == person.Phone.ToString()
            //            )
            //        {
            //            theFoundPeople.Add(person);
            //        }
            //    }
            //    return theFoundPeople;
            //}
            //else
            //{
            //    return null;
            //}
            throw new NotImplementedException();
        }

        public bool Edit(int id, CreatePersonViewModel person)
        {
            foreach (Person temp in _personRepo.GetAll())
                if (temp.PersonId == id)
                {
                    temp.FirstName = person.FirstName;
                    temp.LastName = person.LastName;
                    temp.Age = person.Age;
                    temp.Phone = person.Phone;
                    return true;
                }
            return false;
        }

        public bool Remove(int id)
        {
            foreach (Person temp in _personRepo.GetAll())
                if (id == temp.PersonId)
                {
                    _personRepo.GetAll().Remove(temp);
                    _personRepo.Delete(temp);
                    return true;
                }
            return false;
        }
    }
}
