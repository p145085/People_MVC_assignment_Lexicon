using Microsoft.EntityFrameworkCore;
using People_MVC_assignment_Lexicon.Models.Basemodels;

namespace People_MVC_assignment_Lexicon.Models.Repos
{
    public class DatabasePersonRepo : IPeopleRepo
    {
        readonly PeopleDbContext _context;
        public DatabasePersonRepo(PeopleDbContext context)
        {
            _context = context;
        }

        public Person? Create(Person person)
        {
            _context.People.Add(person);
            _context.SaveChanges();
            return person;
        }

        public void Delete(Person person)
        {
            _context.Remove(person);
            _context.SaveChanges();
        }

        public List<Person>? GetAll()
        {
            return _context.People.Include(p => p.CityFromPerson).ToList();
        }

        public List<Person>? GetByCity(string city)
        {
            return _context.People.Include(p => p.CityFromPerson)
                .Where(
                x => x.CityFromPerson.Name == city
                ).ToList();
        }

        //public List<CityNameFromViewModel>? GetByCityFromCities(string city)
        //{
        //    return _context.Cities
        //        .Where(
        //        x => x.Name == city
        //        ).ToList();
        //}

        public List<Person>? GetById(int id)
        {
            return _context.People.Include(p => p.CityFromPerson)
                .Where(
                x => x.PersonId == id
                ).ToList();
        }

        public List<Person>? GetByName(string name)
        {
            return _context.People.Include(p => p.CityFromPerson)
                .Where(
                x => 
                x.FirstName == name
                ||
                x.LastName == name
                ||
                x.FirstName + x.LastName == name
                ).ToList();
        }

        public void Update(Person person)
        {
            _context.Update(person);
            _context.SaveChanges();
        }
    }
}
