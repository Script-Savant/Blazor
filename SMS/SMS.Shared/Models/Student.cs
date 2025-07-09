using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SMS.Shared.Models;


public class Student : Person
{
    [Key]
    public int Id { get; set; }
    
    //unique
    public string RegNo { get; set; } = string.Empty;
    public  string Country { get; set; } = string.Empty;
    
}