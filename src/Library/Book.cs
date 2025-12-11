using System;

namespace Ucu.Poo.Library
{
    public class Book : IMedia
    {
        public Book(string title, string author, int year, string isbn)
        {
            ArgumentException.ThrowIfNullOrEmpty(title);
            ArgumentException.ThrowIfNullOrEmpty(author);
            if (year < 868 || year > 2025)
            {
                throw new ArgumentException(
                    "El año debe estar entre 1900 y 2025.", nameof(year));
            }
            ArgumentException.ThrowIfNullOrEmpty(isbn);
            
            this.Title = title;
            this.Author = author;
            this.Year = year;
            this.Isbn = isbn;
        }
        
        public string Title { get; private set; }
        public string Author { get; private set; }
        public int Year { get; private set; }
        public string Isbn { get; private set; }

        public int LoanDays()
        {
            return 21;
        }

        public string Describe()
        {
            return $"Book: {this.Title} ({this.Year}), by: {this.Author}; ISBN {this.Isbn}";
        }
    }
}
