using System.Net.Http.Json;
using SMS.Shared.CountryRepository;
using SMS.Shared.Models;

namespace SMS.Client.Services;

public class CountryService : ICountryRepository
{
    private readonly HttpClient _httpClient;

    public CountryService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<Country> AddCountryAsync(Country country)
    {
        var result = await _httpClient.PostAsJsonAsync("api/countries/add-country", country);
        if (!result.IsSuccessStatusCode)
            throw new Exception($"AddCountry failed: {result.StatusCode}");

        var response = await result.Content.ReadFromJsonAsync<Country>();
        return response ?? throw new Exception("AddCountry returned null.");
    }

    public async Task<Country> UpdateCountryAsync(int id, Country country)
    {
        var result = await _httpClient.PutAsJsonAsync($"api/countries/update-country/{id}", country);
        if (!result.IsSuccessStatusCode)
            throw new Exception($"UpdateCountry failed: {result.StatusCode}");

        var response = await result.Content.ReadFromJsonAsync<Country>();
        return response ?? throw new Exception("UpdateCountry returned null.");
    }

    public async Task<Country> DeleteCountryAsync(int countryId)
    {
        var result = await _httpClient.DeleteAsync($"api/countries/delete-country/{countryId}");
        if (!result.IsSuccessStatusCode)
            throw new Exception($"DeleteCountry failed: {result.StatusCode}");

        var response = await result.Content.ReadFromJsonAsync<Country>();
        return response ?? throw new Exception("DeleteCountry returned null.");
    }

    public async Task<IEnumerable<Country>> GetAllCountriesAsync()
    {
        var response = await _httpClient.GetAsync("api/countries/all-countries");
        if (!response.IsSuccessStatusCode)
            throw new Exception($"GetAllCountries failed: {response.StatusCode}");

        var countries = await response.Content.ReadFromJsonAsync<List<Country>>();
        return countries ?? new List<Country>();
    }

    public async Task<Country> GetCountryByIdAsync(int countryId)
    {
        var result = await _httpClient.GetAsync($"api/countries/single-country/{countryId}");
        if (!result.IsSuccessStatusCode)
            throw new Exception($"GetCountryById failed: {result.StatusCode}");

        var response = await result.Content.ReadFromJsonAsync<Country>();
        return response ?? throw new Exception("GetCountryById returned null.");
    }
}
