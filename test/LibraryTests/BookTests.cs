using System;
using NUnit.Framework;

namespace Ucu.Poo.Library.Tests
{
    [TestFixture]
    public class BookTests
    {
        [Test]
        public void Constructor_WithValidData_Succeeds()
        {
            var book = new Book(
                title: "Cien años de soledad",
                year: 1967,
                author: "Gabriel García Márquez",
                isbn: "978-8497592208");

            Assert.That(book, Is.Not.Null);
            Assert.That(book.Title, Is.EqualTo("Cien años de soledad"));
            Assert.That(book.Year, Is.EqualTo(1967));
            Assert.That(book.Author, Is.EqualTo("Gabriel García Márquez"));
            Assert.That(book.Isbn, Is.EqualTo("978-8497592208"));
        }

        [Test]
        public void Constructor_WithInvalidYear_ThrowsException()
        {
            Assert.That(() => new Book(
                title: "Cien años de soledad",
                year: 867,
                author: "Gabriel García Márquez",
                isbn: "978-8497592208"), Throws.TypeOf<ArgumentException>());
        }

        [Test]
        public void LoanDays_ReturnsValidDays()
        {
            var book = new Book(
                title: "Cien años de soledad",
                year: 1967,
                author: "Gabriel García Márquez",
                isbn: "978-8497592208");

            Assert.That(book.LoanDays(), Is.EqualTo(21));
        }

        [Test]
        public void Describe_ReturnsFormattedText()
        {
            var book = new Book(
                title: "Cien años de soledad",
                year: 1967,
                author: "Gabriel García Márquez",
                isbn: "978-8497592208"
            );

            var expected = book.Describe();

            Assert.That(expected, Is.EqualTo(
                "Book: Cien años de soledad (1967), by: Gabriel García Márquez; ISBN 978-8497592208"));
        }
    }
}
