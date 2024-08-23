using System.Text.Json;
using Bibleoteksapp.DTO;
namespace Bibleoteksapp;

class Program
{
    private static Library library = new();
    static void Main(string[] args)
    {
        initialize();

        while (true)
        {
            Console.WriteLine("Welcome to the library!");
            Console.WriteLine("1. Add book");
            Console.WriteLine("2. Remove book");
            Console.WriteLine("3. List books");
            Console.WriteLine("4. Save to json");
            Console.WriteLine("5. Loan book");
            Console.WriteLine("6. List loaned books");
            Console.WriteLine("7. Return book");
            Console.WriteLine("0. Exit");
            string input = Console.ReadLine();
            
            switch (input)
            {
                case "1":
                    AddBook();
                    break;
                case "2":
                    RemoveBook();
                    break;
                case "3":
                    library.PrintBooks();
                    break;
                case "4":
                    jsonserialize();
                    break;
                case "5":
                    loanBook();
                    break;
                case "6":
                    library.printLoanedBooks();
                    break;
                case "7":
                    returnbook();
                    break;
                case "0":
                    jsonserialize();
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid input");
                    break;
            }

        }
    }

    public static void initialize()
    { 
        string filepath = "/Users/Shadeisroot/Documents/json.json"; 
        if (File.Exists(filepath)) 
        { 
            string json = File.ReadAllText(filepath);
            Console.WriteLine("JSON file found and loaded");
            try
            {
                library.LoanedBooks = JsonSerializer.Deserialize<Library>(json).LoanedBooks;
                Console.WriteLine("Loaned books loaded");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            try
            {
                library.Books = JsonSerializer.Deserialize<Library>(json).Books;
                Console.WriteLine("Books loaded");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            try
            {
                library = JsonSerializer.Deserialize<Library>(json);
                Console.WriteLine("Library loaded");

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        else
        {
            Console.WriteLine("No JSON file found");
        }
        
    }


    public static void AddBook()
    {
        
        Console.WriteLine("Enter the title of the book: or press 0 to return");
        string title = Console.ReadLine();
        if (title == "0") return;
        Console.WriteLine("Enter the author of the book: press 0 to return ");
        string author = Console.ReadLine();
        if (author == "0") return;
        Console.WriteLine("Enter the year the book was published: press 0 to return");
        int year = int.Parse(Console.ReadLine());
        if (year == 0) return;
        Console.WriteLine("Enter the ISBN of the book: press 0 to return");
        string isbn = Console.ReadLine();
        if (isbn == "0") return;
        int id = library.Books.Count + 1;
        
        Book book2 = new Book(title, author, year, isbn, id);
        library.AddBook(book2);
        ;


        // Add book to list of books
    }

    public static void RemoveBook()
    {
        library.PrintBooks();
        Console.WriteLine("Enter the id of the book you want to remove: press 0 to return");
        int id = int.Parse(Console.ReadLine());
        if (id == 0) return;
        library.RemoveBook(library.Books[id - 1]);
        library.PrintBooks();
        
    }
    
    public static void loanBook()
    {
        library.PrintBooks();
        Console.WriteLine("Enter the id of the book you want to loan: press 0 to return");
        int id = int.Parse(Console.ReadLine());
        if (id == 0) return;
        library.LoanBook(library.Books[id - 1]);
        library.PrintBooks();
    }
    
    public static void returnbook()
    {
        library.printLoanedBooks();
        Console.WriteLine("Enter the id of the book you want to return: press 0 to return");
        int id = int.Parse(Console.ReadLine());
        if (id == 0) return;
        library.AddBook(library.LoanedBooks[id - 1]);
        library.LoanedBooks.Remove(library.LoanedBooks[id - 1]);
        library.printLoanedBooks();
    }
    
    public static void jsonserialize()
    {

        string json = JsonSerializer.Serialize(library, new JsonSerializerOptions()
        {
            WriteIndented = true
        });
        File.WriteAllText("/Users/Shadeisroot/Documents/json.json", json);
    }
    
}