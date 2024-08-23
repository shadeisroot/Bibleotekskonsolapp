namespace Bibleoteksapp.DTO;

public class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int year { get; set; }
    public string ISBN { get; set; }
    
    public int Id { get; set; }
    
    public Book(string title, string author, int year, string isbn, int id)
    {
        Id = id;
        Title = title;
        Author = author;
        this.year = year;
        ISBN = isbn;
    }
    
    
}