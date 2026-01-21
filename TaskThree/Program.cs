namespace TaskThree
{
    internal class Program
    {
        public class Book
        {
            public string title;
            public string author;
            public string isbn;
            public bool availability;
            public Book(string title, string author, string isbn)
            {
                this.title = title;
                this.author = author;
                this.isbn = isbn;
                this.availability = true;
            }
        }
        public class Library
        {
            public List<Book> books;
            public Library()
            {
                books = new List<Book>();
            }
            public string AddBook(Book book)
            {
                for (int i = 0; i < books.Count; i++)
                {
                    if (books[i].isbn == book.isbn)
                    {
                        return "Book with this ISBN already exists.";
                    }
                }
                books.Add(book);
                return "Book added successfully.";
            }
            public void DisplayBooks()
            {
                if (books.Count == 0)
                {
                    Console.WriteLine("No books in the library.");
                    return;
                }
                for (int i = 0; i < books.Count; i++)
                {
                    Console.WriteLine($"Title: {books[i].title}, Author: {books[i].author}, ISBN: {books[i].isbn}, Available: {books[i].availability}");
                }
            }
            public List<Book> SearchBook(string keyword)
            {
                List<Book> result = new List<Book>();
                for (int i = 0; i < books.Count; i++)
                {
                    if (books[i].title.ToLower().Contains(keyword.ToLower()) || books[i].author.ToLower().Contains(keyword.ToLower()))
                    {
                        result.Add(books[i]);
                    }
                }
                return result;
            }
            public string BorrowBook(string isbn)
            {
                if (books.Count == 0)
                {
                    return "No books in the library.";
                }
                for (int i = 0; i < books.Count; i++)
                {
                    if (!(books[i].isbn == isbn))
                    {
                        return "Invalid ISBN.";
                    }
                    if (books[i].isbn == isbn && books[i].availability)
                    {
                        books[i].availability = false;
                        return "Book borrowed successfully.";
                    }
                }
                return "Book not available for borrowing.";
            }
            public string ReturnBook(string isbn)
            {
                if (books.Count == 0)
                {
                    return "No books in the library.";
                }
                for (int i = 0; i < books.Count; i++)
                {
                    if (!(books[i].isbn == isbn))
                    {
                        return "Invalid ISBN.";
                    }
                    if (books[i].isbn == isbn && !books[i].availability)
                    {
                        books[i].availability = true;
                        return "Book returned successfully.";
                    }
                }
                return "Book already returned.";
            }
        }
        static void Main(string[] args)
        {
            string selectedOption = "";
            Library library = new Library();
            do
            {
                Console.WriteLine("Menu Options:");
                Console.WriteLine("A - Add a book");
                Console.WriteLine("D - Display all books");
                Console.WriteLine("S - Search a book by title");
                Console.WriteLine("B - Borrow a book");
                Console.WriteLine("R - Return a book");
                Console.WriteLine("Q - Quit");
                Console.Write("Enter your choice: ");
                selectedOption = Console.ReadLine();
                switch (selectedOption.ToUpper())
                {
                    case "A":
                        Console.Write("Enter Book Title: ");
                        string title = Console.ReadLine();
                        Console.Write("Enter Book Author: ");
                        string author = Console.ReadLine();
                        Console.Write("Enter Book ISBN: ");
                        string isbn = Console.ReadLine();
                        Console.WriteLine(library.AddBook(new Book(title, author, isbn)));
                        break;
                    case "D":
                        library.DisplayBooks();
                        break;
                    case "S":
                        Console.Write("Enter keyword to search: ");
                        string keyword = Console.ReadLine();
                        List<Book> foundBooks = library.SearchBook(keyword);
                        if (foundBooks.Count == 0)
                        {
                            Console.WriteLine("No books found or invalid.");
                        }
                        else
                        {
                            for (int i = 0; i < foundBooks.Count; i++)
                            {
                                Console.WriteLine($"Title: {foundBooks[i].title}, Author: {foundBooks[i].author}, ISBN: {foundBooks[i].isbn}, Available: {foundBooks[i].availability}");
                            }
                        }
                        break;
                    case "B":
                        Console.Write("Enter the ISBN of the book to borrow: ");
                        string borrowIsbn = Console.ReadLine();
                        Console.WriteLine(library.BorrowBook(borrowIsbn));
                        break;
                    case "R":
                        Console.Write("Enter the ISBN of the book to return: ");
                        string returnIsbn = Console.ReadLine();
                        Console.WriteLine(library.ReturnBook(returnIsbn));
                        break;
                    case "Q":
                        Console.WriteLine("Goodbye");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Unknown option, please try again.");
                        break;
                }
                Console.WriteLine("========================================");
            }
            while (selectedOption != "Q");
        }
    }
}
