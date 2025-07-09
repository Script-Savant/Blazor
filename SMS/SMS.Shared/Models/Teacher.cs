using System.ComponentModel.DataAnnotations;

namespace SMS.Shared.Models;

public enum Designation
{
    
}

public class Teacher : Person
{
    [Key]
    public int Id { get; set; }
    public MaritalStatus? MaritalStatus { get; set; }
    public string? FacebookLink { get; set; }
    public string? TwitterLink { get; set; }
    public string? LinkedInLink { get; set; }
    public Designation? Designation { get; set; }
}