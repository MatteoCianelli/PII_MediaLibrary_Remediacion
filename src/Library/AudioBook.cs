using System;

namespace Ucu.Poo.Library
{
    public class AudioBook
    {
        public AudioBook(string title, string narrator, int year, string isbn)
        {
            ArgumentException.ThrowIfNullOrEmpty(title);
            ArgumentException.ThrowIfNullOrEmpty(narrator);
            if (year < 1870 || year > 2025)
            {
                throw new ArgumentException(
                    "El año debe estar entre 1870 y 2025.", nameof(year));
            }
            ArgumentException.ThrowIfNullOrEmpty(isbn);
            
            this.Title = title;
            this.Narrator = narrator;
            this.Year = year;
            this.Isbn = isbn;
        }
        
        public string Title { get; private set; }
        public string Narrator { get; private set; }
        public int Year { get; private set; }
        public string Isbn { get; private set; }

        public int LoanDays()
        {
            return 14;
        }

        public string Describe()
        {
            return $"AudioBook: {this.Title} ({this.Year}), by: {this.Narrator}; ISBN {this.Isbn}";
        }
    }
}