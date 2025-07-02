using System.ComponentModel.DataAnnotations;

namespace SMS.Shared.Models;

public class SystemCodeDetail
{
    [Key]
    public int Id { get; set; }
    public string Code { get; set; } = string.Empty;
    public string Description { get; set; } = String.Empty;
    
    public int SystemCodeId { get; set; }
    public SystemCode SystemCode { get; set; }
}