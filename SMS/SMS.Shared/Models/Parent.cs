using System.ComponentModel.DataAnnotations;

namespace SMS.Shared.Models;

public enum ParentType
{
    Dad,
    Mum,
    Guardian
}

public class Parent
{
    public int Id { get; set; }
    public string? GovtNumber { get; set; }
    public string? EmploymentStatus { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string? MiddleName { get; set; }
    public string LastName { get; set; } = string.Empty;
    
    [EmailAddress]
    public string? EmailAddress { get; set; }
    
    public string PhoneNumber { get; set; } =  string.Empty;
    public GenderType? Gender { get; set; }
    public string? Address { get; set; }
    public ParentType? DadOrMum { get; set; }
    
    public int StudentId { get; set; }
    public Student? Student { get; set; }
}