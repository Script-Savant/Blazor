namespace SMS.Shared.Models;

public class Department : UserCreateActivity
{
    public  int Id { get; set; }
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
}