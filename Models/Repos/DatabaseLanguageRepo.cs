using People_MVC_assignment_Lexicon.Models.Basemodels;
using System;

namespace People_MVC_assignment_Lexicon.Models.Repos
{
    public class DatabaseLanguageRepo : ILanguageRepo
    {
        readonly PeopleDbContext _context;
        public DatabaseLanguageRepo(PeopleDbContext context)
        {
            _context = context;
        }
        public Language Create(Language language)
        {
            _context.Languages.Add(language);
            _context.SaveChanges();
            return language;
        }

        public void Delete(Language language)
        {
            _context.Languages.Remove(language);
            _context.SaveChanges();
        }

        public List<Language> GetAll()
        {
            return _context.Languages.ToList();
        }

        public List<Language> GetByAny(string search)
        {
            //return _context.Languages
            //    .Where(
            //    x => x.Name == search
            //    ).ToList();
            throw new NotImplementedException();
        }

        public Language GetById(int id)
        {
            // .SELECT och .WHERE fungerar inte.
            //return _context.Languages
            //    .Select(
            //    x => x.CityIdFromPerson == id
            //    );
            return _context.Languages.SingleOrDefault(x => x.LanguageId == id);
        }

        public List<Language> GetByLanguage(string language)
        {
            return _context.Languages
                .Where(
                x => x.Name.Equals(language)
                ).ToList();
        }

        public List<Language> GetByName(string name)
        {
            return _context.Languages
                .Where(
                x => x.Name.Equals(name)
                ).ToList();
        }

        public void Update(Language language)
        {
            _context.Update(language);
            _context.SaveChanges();
        }
    }
}
