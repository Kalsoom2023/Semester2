using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task4.bl;

namespace Task4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Book> books = new List<Book>();

            Book book1 = new Book("Pride and Prejudice", "Jane Austen", "1813", 19.99, 10);
            Book book2 = new Book("Hamlet", "William Shakespeare", "1603", 15.50, 15);
            Book book3 = new Book("War and Peace", "Leo Tolstoy", "1869", 25.99, 20);

            books.Add(book1);
            books.Add(book2);
            books.Add(book3);

            int choice=0;
            while (choice != 7) 
            {
                
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Add Book");
                Console.WriteLine("2. View All the Books information");
                Console.WriteLine("3. Get the Author details of a specific book");
                Console.WriteLine("4. Sell Copies of a Specific Book");
                Console.WriteLine("5. Restock a Specific Book");
                Console.WriteLine("6. See the count of the Books present in your bookList");
                Console.WriteLine("7. Exit");
                Console.Write("Enter your choice: ");
                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                       
                        Console.WriteLine("Enter the title of the book:");
                        string title = Console.ReadLine();
                        Console.WriteLine("Enter the author of the book:");
                        string author = Console.ReadLine();
                        Console.WriteLine("Enter the publication year of the book:");
                        string publicationYear = Console.ReadLine();
                        Console.WriteLine("Enter the price of the book:");
                        double price = double.Parse(Console.ReadLine());
                        Console.WriteLine("Enter the quantity in stock of the book:");
                        int quantityInStock = int.Parse(Console.ReadLine());

                      
                        Book Book = new Book(title, author, publicationYear, price, quantityInStock);
                        books.Add(Book);
                        break;

                    case 2:
                        
                        for (int i = 0; i < books.Count; i++)
                        {
                            Console.WriteLine(books[i].BookDetails());
                        }

                        break;

                    case 3:
                        
                        Console.WriteLine("Enter the title:");
                        string searchTitle = Console.ReadLine();
                        for (int i = 0; i < books.Count; i++)
                        {
                            if(books[i].Title==searchTitle)
                            {
                                Console.WriteLine($"Author of \"{searchTitle}\": {books[i].Author}");
                            }
                           
                        }
                        Console.WriteLine("Not found");
                        break;

                    case 4:
                        Console.WriteLine("Enter the title of the book:");
                        string sellTitle = Console.ReadLine();
                        for (int i = 0; i < books.Count; i++)
                        {
                            if (books[i].Title == sellTitle)
                            {
                                Console.WriteLine("Enter the number of copies to sell:");
                                int numberOfCopies = int.Parse(Console.ReadLine());
                                books[i].SellCopies(numberOfCopies);
                                break;
                            }
                           
                        }
                       
                            Console.WriteLine("Not found");
                        
                        break;

                    case 5:
                        Console.WriteLine("Enter the title of the book:");
                        string restockTitle = Console.ReadLine();
                        for (int i = 0; i < books.Count; i++)
                        {
                            if (books[i].Title == restockTitle)
                            {
                                Console.WriteLine("Enter the number of copies to restock:");
                                int additionalCopies = int.Parse(Console.ReadLine());
                                books[i].Restock(additionalCopies);
                                break;
                            }
                        }
                        Console.WriteLine("Not found");

                        break;

                    case 6:
                        
                        Console.WriteLine("Count of Books present in the bookList: " + books.Count);
                        break;

                    case 7:
                        Console.WriteLine("Exiting");
                        break;

                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }
    }
}
    
