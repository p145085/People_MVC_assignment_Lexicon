using People_MVC_assignment_Lexicon.Models.Basemodels;

namespace People_MVC_assignment_Lexicon.Models.Repos
{
    public class DatabaseCountryRepo : ICountryRepo
    {
        readonly PeopleDbContext _context;
        public DatabaseCountryRepo(PeopleDbContext context)
        {
            _context = context;
        }
        public Country Create(Country country)
        {
            _context.Countries.Add(country);
            _context.SaveChanges();
            return country;
        }

        public void Delete(Country country)
        {
            _context.Countries.Remove(country);
            _context.SaveChanges();
        }

        public List<Country> GetAll()
        {
            return _context.Countries.ToList();
        }

        public List<Country> GetByAny(string search)
        {
            //return _context.Countries
            //    .Where(
            //    x => x.Name == search
            //    ).ToList();
            throw new NotImplementedException();
        }

        public Country GetById(int id)
        {
            // .SELECT och .WHERE fungerar inte.
            //return _context.Languages
            //    .Select(
            //    x => x.CityIdFromPerson == id
            //    );
            return _context.Countries.SingleOrDefault(x => x.CountryId == id);

        }

        public List<Country> GetByCountry(string country)
        {
            return _context.Countries
                .Where(
                x => x.Name.Equals(country)
                ).ToList();
        }

        public List<Country> GetByName(string name)
        {
            return _context.Countries
                .Where(
                x => x.Name.Equals(name)
                ).ToList();
        }

        public void Update(Country country)
        {
            _context.Update(country);
            _context.SaveChanges();
        }
    }
}
