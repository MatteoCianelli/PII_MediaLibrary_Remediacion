using System;
using NUnit.Framework;

namespace Ucu.Poo.Library.Tests
{
    [TestFixture]
    public class BooksRepositoryTests
    {
        private static Book CreateBook(string title = "Cien años de soledad",
            string author = "Gabriel García Márquez",
            int year = 1967,
            string isbn = "978-8497592208")
        {
            return new Book(title, author, year, isbn);
        }

        [Test]
        public void AddBook_WithValidBook_AddsToBooks()
        {
            BooksRepository repository = new BooksRepository();
            Book book = CreateBook();

            repository.Add(book);

            Assert.That(repository.Items.Count.Equals(1));
            Assert.That(repository.Items, Contains.Item(book));
        }

        [Test]
        public void FindById_WithExistingId_ReturnsBook()
        {
            BooksRepository repository = new BooksRepository();
            Book book = CreateBook();
            repository.Add(book);
            
            Book actual = repository.FindById("978-8497592208");

            Assert.That(actual, Is.EqualTo(book));
        }

        [Test]
        public void FindById_WithNonExistingId_ReturnsNull()
        {
            BooksRepository repository = new BooksRepository();
            Book book = CreateBook();
            repository.Add(book);

            Book actual = repository.FindById("000-0000000000");

            Assert.That(actual, Is.Null);
        }
        
        [Test]
        public void FindByTitle_WithExistingTitle_ReturnsBook()
        {
            BooksRepository repository = new BooksRepository();
            Book book = CreateBook();
            repository.Add(book);
            
            Book actual = repository.FindByTitle("Cien años de soledad");

            Assert.That(actual, Is.EqualTo(book));
        }

        [Test]
        public void FindByTitle_WithNonExistingTitle_ReturnsNull()
        {
            BooksRepository repository = new BooksRepository();
            Book book = CreateBook();
            repository.Add(book);

            Book actual = repository.FindByTitle("El otoño del patriarca");

            Assert.That(actual, Is.Null);
        }
    }
}
