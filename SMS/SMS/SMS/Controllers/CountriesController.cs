using Microsoft.AspNetCore.Mvc;
using SMS.Shared.CountryRepository;
using SMS.Shared.Models;

namespace SMS.Controllers
{
    [Route("api/countries")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly ICountryRepository _countryRepository;

        public CountriesController(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        // GET: api/Countries
        [HttpGet("all-countries")]
        public async Task<ActionResult<IEnumerable<Country>>> GetAllCountries()
        {
            var countries = await _countryRepository.GetAllCountriesAsync();
            return Ok(countries);
        }

        // GET: api/Countries/5
        [HttpGet("single-country/{id}")]
        public async Task<ActionResult<Country>> GetCountryById(int id)
        {
            var country = await _countryRepository.GetCountryByIdAsync(id);
            
            return Ok(country);
        }

        // PUT: api/Countries/5
        [HttpPut("update-country/{id}")]
        public async Task<IActionResult> UpdateCountry(int id, Country country)
        {
            var countryToUpdate = await _countryRepository.UpdateCountryAsync(id, country);

            return Ok(countryToUpdate);
        }

        // POST: api/Countries
        [HttpPost("add-country")]
        public async Task<ActionResult<Country>> AddCountry(Country country)
        {
            var countryToAdd = await _countryRepository.AddCountryAsync(country);
            
            return Ok(countryToAdd);
        }

        // DELETE: api/Countries/5
        [HttpDelete("delete-country/{id}")]
        public async Task<IActionResult> DeleteCountry(int id)
        {
            var countryToDelete = await _countryRepository.DeleteCountryAsync(id);
            
            return Ok(countryToDelete);
        }
        
    }
}
