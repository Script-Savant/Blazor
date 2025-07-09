using System.ComponentModel.DataAnnotations;

namespace SMS.Shared.Models;

public enum MaritalStatus
{
    Single,
    Married,
    Divorced,
    Widowed
}

public enum GenderType
{
    Male,
    Female,
    Other
}

public class Person
{
    public string FirstName { get; set; } = String.Empty;
    public string? MiddleName { get; set; }
    public string LastName { get; set; } = String.Empty;
    public string FullName => $"{FirstName} {MiddleName} {LastName}".Trim();
    
    [EmailAddress]
    public string EmailAddress { get; set; } = String.Empty;
    
    public string PhoneNumber { get; set; } = String.Empty;
    public string? Address { get; set; }
    public GenderType? Gender { get; set; }
    public DateOnly? BirthDate { get; set; } 
}