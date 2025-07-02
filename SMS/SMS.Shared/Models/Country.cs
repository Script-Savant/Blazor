using System.ComponentModel.DataAnnotations;

namespace SMS.Shared.Models;

public class Country
{
    [Key]
    public int Id { get; set; }
    public string Code { get; set; } = String.Empty;
    public string Name { get; set; } = String.Empty;
}