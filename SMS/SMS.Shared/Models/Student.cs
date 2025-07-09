using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SMS.Shared.Models;

public enum GenderType
{
    Male,
    Female,
    Other
}

public class Student
{
    [Key]
    public int Id { get; set; }
    
    //unique
    public required string RegNo { get; set; }
    
    public required string FirstName { get; set; }
    public required string MiddleName { get; set; }
    public required string LastName { get; set; }
    public string FullName => $"{FirstName} {MiddleName} {LastName}".Trim();
    
    [EmailAddress]
    public required string EmailAddress { get; set; }
    
    public required string PhoneNumber { get; set; }
    public string? StudentAddress { get; set; }
    public required string Country { get; set; }
    public DateOnly? BirthDate { get; set; }
    public GenderType? Gender { get; set; }
}