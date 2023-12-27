using BasicWebApi.Domain.Models;

namespace BasicWebApi.Services.Interfaces
{
    public interface ICountryService
    {
        Country GetCountry(int countryId);
        List<Country> GetCountries();
        int CreateCountry(Country country);
        Country UpdateCountry(int countryId, Country country);
        void DeleteCountry(int countryId);
    }
}