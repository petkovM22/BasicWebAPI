using BasicWebApi.DataAccess;
using BasicWebApi.Domain.Models;
using BasicWebApi.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BasicWebApi.Services.Implementations
{
    public class CountryService : ICountryService
    {
        private readonly BasicWebApiDbContext _dbContext;

        public CountryService(BasicWebApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Country GetCountry(int countryId)
        {
            return _dbContext.Countries.Find(countryId);
        }

        public List<Country> GetCountries()
        {
            return _dbContext.Countries.ToList();
        }

        public int CreateCountry(Country country)
        {
            _dbContext.Countries.Add(country);
            _dbContext.SaveChanges();
            return country.Id;
        }

        public Country UpdateCountry(int countryId, Country country)
        {
            var existingCountry = _dbContext.Countries.Find(countryId);
            if (existingCountry != null)
            {
                existingCountry.CountryName = country.CountryName;
                _dbContext.SaveChanges();
            }
            return existingCountry;
        }

        public void DeleteCountry(int countryId)
        {
            var countryToDelete = _dbContext.Countries.Find(countryId);
            if (countryToDelete != null)
            {
                _dbContext.Countries.Remove(countryToDelete);
                _dbContext.SaveChanges();
            }
        }
    }
}