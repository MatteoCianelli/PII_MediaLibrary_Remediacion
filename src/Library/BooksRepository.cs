using System.Collections.Generic;

namespace Ucu.Poo.Library
{
    public class BooksRepository
    {
        private List<Book> books = new List<Book>();

        public IReadOnlyCollection<Book> Items
        {
            get
            {
                return this.books.AsReadOnly();
            }
        }
        
        public Book FindById(string id)
        {
            foreach (Book book in books)
            {
                if (book.CheckId(id))
                {
                    return book;
                }
            }
            
            return null;
        }
        
        public Book FindByTitle(string title)
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

        public void Add(Book book)
        {
            this.books.Add(book);
        }
    }
}
