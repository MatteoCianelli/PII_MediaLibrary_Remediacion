using System.Collections.Generic;

namespace Ucu.Poo.Library
{
    public class MoviesRepository
    {
        private List<Movie> movies = new List<Movie>();

        public IReadOnlyCollection<Movie> Items
        {
            get
            {
                return this.movies.AsReadOnly();
            }
        }
        
        public Movie FindById(string id)
        {
            foreach (Movie movie in Items)
            {
                if (movie.CheckId(id))
                {
                    return movie;
                }
            }
            return null;
        }
        
        public Movie FindByTitle(string title)
        {
            foreach (Movie movie in Items)
            {
                if (movie.Title == title)
                {
                    return movie;
                }
            }
            
            return null;
        }

        public void Add(Movie movie)
        {
            this.movies.Add(movie);
        }
    }
}
