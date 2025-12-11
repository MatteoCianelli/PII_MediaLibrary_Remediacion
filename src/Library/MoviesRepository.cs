using System.Collections.Generic;

namespace Ucu.Poo.Library
{
    public class MoviesRepository : IRepository
    {
        private List<IMedia> movies = new List<IMedia>();

        public IReadOnlyCollection<IMedia> Items
        {
            get
            {
                return this.movies.AsReadOnly();
            }
        }
        
        public IMedia FindById(string id)
        {
            foreach (Movie movie in Items)
            {
                if (movie.ImdbId == id)
                {
                    return movie;
                }
            }
            return null;
        }
        
        public IMedia FindByTitle(string title)
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

        public void Add(IMedia media)
        {
            this.movies.Add(media);
        }
    }
}
