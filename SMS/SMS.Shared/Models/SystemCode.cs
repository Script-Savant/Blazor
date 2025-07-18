using System.ComponentModel.DataAnnotations;

namespace SMS.Shared.Models;

public class SystemCode
{
    [Key]
    public int Id { get; set; }
    public string Code { get; set; } = string.Empty;
    public string Description { get; set; } = String.Empty;
}