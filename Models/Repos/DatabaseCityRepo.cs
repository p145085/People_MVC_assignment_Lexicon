using People_MVC_assignment_Lexicon.Models.Basemodels;
using People_MVC_assignment_Lexicon.Models.Services;

namespace People_MVC_assignment_Lexicon.Models.Repos
{
    public class DatabaseCityRepo : ICityRepo
    {
        readonly PeopleDbContext _context;
        public DatabaseCityRepo(PeopleDbContext context)
        {
            _context = context;
        }
        public City Create(City city)
        {
            _context.Cities.Add(city);
            _context.SaveChanges();
            return city;
        }

        public void Delete(City city)
        {
            _context.Cities.Remove(city);
            _context.SaveChanges();
        }

        public List<City> GetAll()
        {
            return _context.Cities.ToList();
        }

        public List<City> GetByAny(string search)
        {
            //return _context.Cities
            //    .Where(
            //    x => x.Name == search
            //    ).ToList();
            throw new NotImplementedException();
        }

        public City GetById(int id)
        {
            // .SELECT och .WHERE fungerar inte.
            //return _context.Languages
            //    .Select(
            //    x => x.CityId == id
            //    );
            return _context.Cities.SingleOrDefault(x => x.CityId == id);
        }

        public List<City> GetByCity(string city)
        {
            return _context.Cities
                .Where(
                x => x.Name.Equals(city)
                ).ToList();
        }

        public List<City> GetByName(string name)
        {
            return _context.Cities
                .Where(
                x => x.Name.Equals(name)
                ).ToList();
        }

        public void Update(City city)
        {
            _context.Update(city);
            _context.SaveChanges();
        }
    }
}
