using SMS.Shared.Models;

namespace SMS.Shared.CountryRepository;

public interface ICountryRepository
{
    Task<Country> AddCountryAsync(Country country);
    Task<Country> UpdateCountryAsync(int countryId, Country country);
    Task<Country> DeleteCountryAsync(int countryId);
    Task<IEnumerable<Country>> GetAllCountriesAsync();
    Task<Country> GetCountryByIdAsync(int countryId);
}