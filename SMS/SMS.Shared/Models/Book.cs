namespace SMS.Shared.Models;

public class Book
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public int Copies  { get; set; }
    
    public int BookCategoryId { get; set; }
    public BookCategory? BookCategory { get; set; }
}