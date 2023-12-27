using BasicWebApi.Domain.Models;
using BasicWebApi.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BasicWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryService _countryService;

        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        [HttpGet]
        public ActionResult<List<Country>> GetCountries()
        {
            try
            {
                var countries = _countryService.GetCountries();
                return Ok(countries);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }

        [HttpGet("{countryId}")]
        public ActionResult<Country> GetCountry(int countryId)
        {
            try
            {
                var country = _countryService.GetCountry(countryId);
                if (country == null)
                {
                    return NotFound();
                }
                return Ok(country);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }

        [HttpPost]
        public ActionResult<int> CreateCountry([FromBody] Country country)
        {
            try
            {
                var countryId = _countryService.CreateCountry(country);
                return Ok(countryId);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }

        [HttpPut("{countryId}")]
        public ActionResult<Country> UpdateCountry(int countryId, [FromBody] Country country)
        {
            try
            {
                var updatedCountry = _countryService.UpdateCountry(countryId, country);
                if (updatedCountry == null)
                {
                    return NotFound();
                }
                return Ok(updatedCountry);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }

        [HttpDelete("{countryId}")]
        public ActionResult DeleteCountry(int countryId)
        {
            try
            {
                _countryService.DeleteCountry(countryId);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }
    }
}