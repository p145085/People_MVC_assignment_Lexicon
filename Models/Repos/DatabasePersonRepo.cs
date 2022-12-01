using Microsoft.CodeAnalysis.CSharp.Syntax;
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

        public Person Create(Person person)
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

        public List<Person> GetAll()
        {
            return _context.People.ToList();
        }

        public List<Person> GetByCity(string city)
        {
            return _context.People
                .Where(
                x => x.City.Name == city
                ).ToList();
        }

        public Person GetById(int id)
        {
            return _context.People.SingleOrDefault(x => x.Id == id);

                //.Where(
                //x => x.Id == id
                //);
        }

        public List<Person> GetByName(string name)
        {
            return _context.People
                .Where(
                x => 
                x.FirstName == name
                ||
                x.LastName == name
                ||
                x.FullName == name
                ).ToList();
        }

        public void Update(Person person)
        {
            _context.Update(person);
            _context.SaveChanges();
        }
    }
}
