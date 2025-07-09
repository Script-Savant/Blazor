using System.ComponentModel.DataAnnotations;

namespace SMS.Shared.Models;

public enum ParentType
{
    Dad,
    Mum,
    Guardian
}

public class Parent : Person
{
    public int Id { get; set; }
    public string? GovtNumber { get; set; }
    public string? EmploymentStatus { get; set; }
    public ParentType? DadOrMum { get; set; }
    
    public int StudentId { get; set; }
    public Student? Student { get; set; }
}