using System;

namespace Ucu.Poo.Library
{
    public sealed class Movie : IMedia
    {
        public Movie(string title, string director, int year, string imdbId)
        {
            ArgumentNullException.ThrowIfNull(title, nameof(title));
            ArgumentNullException.ThrowIfNull(director, nameof(director));
            if (year < 1888 || year > 2025)
            {
                throw new ArgumentException(
                    "El año debe estar entre 1900 y 2025.", nameof(year));
            }
            ArgumentNullException.ThrowIfNull(imdbId, nameof(imdbId));
            
            this.Title = title;
            this.Director = director;
            this.Year = year;
            this.ImdbId = imdbId;
        }

        public string Id { get; private set; }
        public string Title { get; private set; }
        public string Director { get; private set; }
        public int Year { get; private set; }
        public string ImdbId { get; private set; }

        public int LoanDays()
        {
            return 7;
        }

        public string Describe()
        {
            return $"Movie: {this.Title} ({this.Year}), directed by: {this.Director}; IMDB Id {this.ImdbId}";
        }
    }
}
