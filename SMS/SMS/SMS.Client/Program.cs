using SMS.Client;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using SMS.Client.Services;
using SMS.Shared.CountryRepository;
using SMS.Shared.StudentRepository;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddAuthorizationCore();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddSingleton<AuthenticationStateProvider, PersistentAuthenticationStateProvider>();

// custom services
builder.Services.AddScoped<IStudentRepository, StudentService>();
builder.Services.AddScoped<ICountryRepository, CountryService>();


// base address
builder.Services.AddScoped(http => new HttpClient
{
    BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
});

await builder.Build().RunAsync();