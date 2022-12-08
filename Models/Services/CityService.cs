using People_MVC_assignment_Lexicon.Models.Basemodels;
using People_MVC_assignment_Lexicon.Models.Repos;
using People_MVC_assignment_Lexicon.Models.ViewModels;
using System;

namespace People_MVC_assignment_Lexicon.Models.Services
{
    public class CityService : ICityService
    {
        ICityRepo _cityRepo;
        public CityService(ICityRepo cityRepo)
        {
            _cityRepo = cityRepo;
        }
        public City Create(CreateCityViewModel createCityViewModel)
        {
            if (string.IsNullOrWhiteSpace(createCityViewModel.City))
            {
                throw new ArgumentException("No whitespace allowed.");
            }

            City city = new City()
            {
                CityId = createCityViewModel.Id,
                Name = createCityViewModel.City,
            };
            city = _cityRepo.Create(city);
            return city;
        }

        public bool Edit(int id, CreateCityViewModel createCityViewModel)
        {
            foreach (City temp in _cityRepo.GetAll())
                if (temp.CityId == id)
                {
                    temp.Name = createCityViewModel.City;
                    return true;
                }
            return false;
        }

        public City GetByCity(string city)
        {
            return _cityRepo.GetByCityName(city);
        }

        public City FindById(int id)
        {
            return _cityRepo.GetById(id);
        }

        //public List<City> FindByName(string name)
        //{
        //    return _cityRepo.GetByName(name);
        //}

        public List<City> GetAll()
        {
            return _cityRepo.GetAll();
        }

        //public List<City> GetByAny(string search)
        //{
        //    List<City> theCities = _cityRepo.GetAll();
        //    List<City> theFoundCities = new List<City>();

        //    if (search != null)
        //    {
        //        foreach (City city in theCities)
        //        {
        //            if (
        //                search == city.CityId.ToString()
        //                || search == city.Name
        //                )
        //            {
        //                theFoundCities.Add(city);
        //            }
        //        }
        //        return theFoundCities;
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}

        public bool Remove(int id)
        {
            foreach (City temp in _cityRepo.GetAll())
                if (id == temp.CityId)
                {
                    _cityRepo.GetAll().Remove(temp);
                    return true;
                }
            return false;
        }
    }
}
