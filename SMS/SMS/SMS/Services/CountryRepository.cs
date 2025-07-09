using Microsoft.EntityFrameworkCore;
using SMS.Data;
using SMS.Shared.Interfaces;
using SMS.Shared.Models;

namespace SMS.Services;

public class CountryRepository : ICountryRepository
{
    private readonly ApplicationDbContext _db;

    public CountryRepository(ApplicationDbContext db)
    {
        _db = db;
    }
    
    public async Task<Country> AddCountryAsync(Country country)
    {
        if (_db.Countries.Any(c => c.Name == country.Name || c.Code == country.Code))
        {
            throw new Exception("Country with that name or code already exists");
        }
        _db.Countries.Add(country);
        await _db.SaveChangesAsync();
        
        return country;
    }

    public async Task<Country> UpdateCountryAsync(int countryId, Country country)
    {
        var data = await GetCountryByIdAsync(countryId);
        
        data.Name = country.Name;
        data.Code = country.Code;
        
        _db.Countries.Update(data);
        await _db.SaveChangesAsync();

        return data;
    }

    public async Task<Country> DeleteCountryAsync(int countryId)
    {
        var country = await GetCountryByIdAsync(countryId);
        
        _db.Countries.Remove(country);
        await _db.SaveChangesAsync();
        
        return country;
    }

    public async Task<IEnumerable<Country>> GetAllCountriesAsync()
    {
        var countries = await _db.Countries
            .OrderBy(c => c.Name)
            .ToListAsync();

        return countries;
    }

    public async Task<Country> GetCountryByIdAsync(int countryId)
    {
        var country = await _db.Countries
            .FirstOrDefaultAsync(c => c.Id == countryId);

        if (country is null) throw new ArgumentNullException();
        
        return country;
    }
}