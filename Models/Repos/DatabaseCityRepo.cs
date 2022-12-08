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

        //public List<City> GetByAny(string search)
        //{
        //    //return _context.Cities
        //    //    .Where(
        //    //    x => x.Name == search
        //    //    ).ToList();
        //    throw new NotImplementedException();
        //}

        public City GetById(int id)
        {
            // .SELECT och .WHERE fungerar inte.
            //return _context.Languages
            //    .Select(
            //    x => x.CityIdFromPerson == id
            //    );
            return _context.Cities.SingleOrDefault(x => x.CityId == id);
        }

        public City GetByCityName(string city)
        {
            if (_context.Cities
                .SingleOrDefault(
                x => x.Name.Equals(city)
                ) 
                == null
                )
            {
                throw new ArgumentException("City does not exist.");
            }
            else
            {
                return _context.Cities
                .SingleOrDefault(
                x => x.Name.Equals(city)
                );
            }
        }

        public void Update(City city)
        {
            _context.Update(city);
            _context.SaveChanges();
        }
    }
}
