using System.Collections.Generic;

namespace Ucu.Poo.Library
{
    public class BooksRepository : IRepository
    {
        private List<IMedia> books = new List<IMedia>();

        public IReadOnlyCollection<IMedia> Items
        {
            get
            {
                return this.books.AsReadOnly();
            }
        }
        
        public IMedia FindById(string id)
        {
            foreach (Book book in books)
            {
                if (book.Isbn == id)
                {
                    return book;
                }
            }
            
            return null;
        }
        
        public IMedia FindByTitle(string title)
        {
            foreach (Book book in books)
            {
                if (book.Title == title)
                {
                    return book;
                }
            }
            
            return null;
        }

        public void Add(IMedia media)
        {
            this.books.Add(media);
        }
    }
}
