namespace SMS.Shared.Models;

public class Subject : UserCreateActivity
{
    public int Id { get; set; }
    public string Name { get; set; } = String.Empty;
    public string Description { get; set; } = String.Empty;
}