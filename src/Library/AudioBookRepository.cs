using System.Collections.Generic;

namespace Ucu.Poo.Library
{
    public class AudioBookRepository
    {
        private List<AudioBook> audioBooks = new List<AudioBook>();

        public IReadOnlyCollection<AudioBook> Items
        {
            get
            {
                return this.audioBooks.AsReadOnly();
            }
        }
        
        public AudioBook FindById(string id)
        {
            foreach (AudioBook audioBook in audioBooks)
            {
                if (audioBook.CheckId(id))
                {
                    return audioBook;
                }
            }
            
            return null;
        }
        
        public AudioBook FindByTitle(string title)
        {
            foreach (AudioBook audioBook in audioBooks)
            {
                if (audioBook.Title == title)
                {
                    return audioBook;
                }
            }
            
            return null;
        }

        public void Add(AudioBook audioBook)
        {
            this.audioBooks.Add(audioBook);
        }
    }
}