using People_MVC_assignment_Lexicon.Models.Basemodels;
using People_MVC_assignment_Lexicon.Models.Repos;
using People_MVC_assignment_Lexicon.Models.ViewModels;
using System;

namespace People_MVC_assignment_Lexicon.Models.Services
{
    public class CountryService : ICountryService
    {
        ICountryRepo _countryRepo;
        public CountryService(ICountryRepo countryRepo)
        {
            _countryRepo = countryRepo;
        }

        public Country Create(CreateCountryViewModel createCountryViewModel)
        {
            if (string.IsNullOrWhiteSpace(createCountryViewModel.Country))
            {
                throw new ArgumentException("No whitespace allowed.");
            }
            Country country = new Country()
            {
                Id = createCountryViewModel.Id,
                Name = createCountryViewModel.Country,
            };
            country = _countryRepo.Create(country);
            return country;
        }

        public bool Edit(int id, CreateCountryViewModel createCountryViewModel)
        {
            foreach (Country temp in _countryRepo.GetAll())
                if (temp.Id == id)
                {
                    temp.Name = createCountryViewModel.Country;
                    return true;
                }
            return false;
        }

        public List<Country> FindByCountry(string country)
        {
            return _countryRepo.GetByCountry(country);
        }

        public Country FindById(int id)
        {
            return _countryRepo.GetById(id);
        }

        public List<Country> FindByName(string name)
        {
            return _countryRepo.GetByName(name);
        }

        public List<Country> GetAll()
        {
            return _countryRepo.GetAll();
        }

        public List<Country> GetByAny(string search)
        {
            return _countryRepo.GetByAny(search);
        }

        public bool Remove(int id)
        {
            foreach (Country temp in _countryRepo.GetAll())
                if (id == temp.Id)
                {
                    _countryRepo.GetAll().Remove(temp);
                    return true;
                }
            return false;
        }
    }
}
