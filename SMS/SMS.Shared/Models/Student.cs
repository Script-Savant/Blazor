using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SMS.Shared.Models;

public class Student
{
    [Key]
    public int Id { get; set; }
    
    //unique
    public required string RegNo { get; set; }
    
    public required string FirstName { get; set; }
    public required string MiddleName { get; set; }
    public required string LastName { get; set; }
    
    [EmailAddress]
    public required string EmailAddress { get; set; }
    
    public required string PhoneNumber { get; set; }
    public string? StudentAddress { get; set; }
    public required string Country { get; set; }
    public DateTime? BirthDate { get; set; }
}