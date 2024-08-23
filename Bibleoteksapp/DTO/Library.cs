namespace Bibleoteksapp.DTO;

public class Library
{
    public List<Book> Books { get; set; } = new List<Book>();

    public List<Book> LoanedBooks { get; set; } = new List<Book>();
    
    public void AddBook(Book book)
    {
        Books.Add(book);
    }
    
    public void RemoveBook(Book book)
    {
        Books.Remove(book);
    }
    
    public void PrintBooks()
    {
        foreach (Book book in Books)
        {
            Console.WriteLine($"Title: {book.Title}, Author: {book.Author}, Year: {book.year}, ISBN: {book.ISBN}, ID: {book.Id}");
        }
    }
    
    public void LoanBook(Book book)
    {
        LoanedBooks.Add(book);
        Books.Remove(book);
    }
    
    public void printLoanedBooks()
    {
        foreach (Book book in LoanedBooks)
        {
            Console.WriteLine($"Title: {book.Title}, Author: {book.Author}, Year: {book.year}, ISBN: {book.ISBN}, ID: {book.Id}");
        }
    }
    
}