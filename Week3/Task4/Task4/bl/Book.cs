using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4.bl
{
    public class Book
    {
        public string Title;
        public string Author;
        public string PublicationYear;
        public double Price;
        public int Quantity;
        public Book(string title, string author, string publicationYear, double price, int quantityInStock)
        {
            this.Title = title;
            this.Author = author;
            this.PublicationYear = publicationYear;
            this.Price = price;
            this.Quantity = quantityInStock;
        }
        public string GetTitle()
        {
            return $"Title: {Title}";
        }

        public string GetAuthor()
        {
            return $"Author: {Author}";
        }

        public string GetPublicationYear()
        {
            return $"Publication Year: {PublicationYear}";
        }

        public string GetPrice()
        {
            return $"Price: ${Price}";
        }
        public void SellCopies(int numberOfCopies)
        {
            if (numberOfCopies <= Quantity)
            {
                Quantity -= numberOfCopies;
                Console.WriteLine($"{numberOfCopies} copies sold successfully.");
            }
            else
            {
                Console.WriteLine($"Error: Not enough copies.");
            }
        }
        public void Restock(int additionalCopies)
        {
            Quantity += additionalCopies;
            Console.WriteLine($"Successfully restocked");
        }
        public string BookDetails()
        {
            return $"{GetTitle()}\n{GetAuthor()}\n{GetPublicationYear()}\n{GetPrice()}\nQuantity in Stock: {Quantity}";
        }
    }
}
