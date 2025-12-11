using System;
using NUnit.Framework;

namespace Ucu.Poo.Library.Tests
{
    [TestFixture]
    public class MediaLibraryTests
    {
        private static User CreateUser(string name = "Ana Pérez")
        {
            return new User(name);
        }

        private static Book CreateBook(string title = "Cien años de soledad",
            string author = "Gabriel García Márquez",
            int year = 1967,
            string isbn = "978-8497592208")
        {
            return new Book(title, author, year, isbn);
        }

        private Movie CreateMovie(string title = "El laberinto del fauno",
            string director = "Guillermo del Toro",
            int year = 2006, string imdbId = "tt0457430")
        {

            return new Movie(title, director, year, imdbId);
        }

        [Test]
        public void AddUser_WithValidUser_AddsToUsers()
        {
            var library = new MediaLibrary();
            var user = CreateUser();

            library.AddUser(user);

            Assert.That(library.Users, Has.Count.EqualTo(1));
            Assert.That(library.Users, Contains.Item(user));
        }

        [Test]
        public void AddUser_WithNull_ThrowsException()
        {
            var library = new MediaLibrary();

            Assert.That(() => library.AddUser(null),
                Throws.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void AddUser_WithDuplicateUserName_ThrowsException()
        {
            var library = new MediaLibrary();
            var user1 = CreateUser();
            var user2 = CreateUser();
            library.AddUser(user1);

            Assert.That(() => library.AddUser(user2),
                Throws.TypeOf<InvalidOperationException>());
        }

        [Test]
        public void FindUserByName_WithExistingUser_ReturnsUser()
        {
            const string userName = "Juan Pérez";
            var library = new MediaLibrary();
            var user = CreateUser(userName);
            library.AddUser(user);

            var found = library.FindUserByName(userName);

            Assert.That(found, Is.Not.Null);
            Assert.That(found, Is.EqualTo(user));
        }

        [Test]
        public void FindUserByName_WithNonExistingUser_ReturnsNull()
        {
            var library = new MediaLibrary();

            var found = library.FindUserByName("No Existe");

            Assert.That(found, Is.Null);
        }

        [Test]
        public void LoanToUser_WithValidData_LoansBook()
        {
            var library = new MediaLibrary();
            var user = CreateUser();
            var book = CreateBook();
            library.AddUser(user);
            library.AddBook(book);

            Loan loan = library.LoanToUser(user, book);

            Assert.That(library.GetUserLoansCount(user), Is.EqualTo(1));
            Assert.That(library.IsLoaned(book), Is.True);
            Assert.That(library.UserHasDueLoans(user), Is.False);
            Assert.That(library.Loans, Does.Contain(loan));
        }

        [Test]
        public void LoanToUser_WithLoanedBook_ThrowsException()
        {
            var library = new MediaLibrary();
            var user1 = CreateUser("Usuario 1");
            var user2 = CreateUser("Usuario 2");
            var book = CreateBook();
            library.AddUser(user1);
            library.AddUser(user2);
            library.AddBook(book);
            library.LoanToUser(user1, book);

            Assert.That(() => library.LoanToUser(user2, book),
                Throws.TypeOf<InvalidOperationException>());
        }
        
        [Test]
        public void LoanToUser_WithDueLoans_ThrowsException()
        {
            var library = new MediaLibrary();
            var user = CreateUser();
            var book1 = CreateBook(title: "Libro 1", year: 2000);
            var book2 = CreateBook(title: "Libro 2", year: 2001);
            library.AddUser(user);
            library.AddBook(book1);
            library.AddBook(book2);
            DateTime oldDate = DateTime.Now.AddDays(-book1.LoanDays() - 1);
            library.LoanToUser(user, book1, oldDate);

            Assert.That(() => library.LoanToUser(user, book2),
                Throws.TypeOf<InvalidOperationException>());
        }
        
        // [Test]
        // public void LoanToUser_WithValidData_LoansMovie()
        // {
        //     var library = new MediaLibrary();
        //     var user = CreateUser();
        //     var movie = CreateMovie();
        //     library.AddUser(user);
        //     library.AddMovie(movie);
        //
        //     library.LoanToUser(user, movie);
        //
        //     Assert.That(library.GetUserLoansCount(user), Is.EqualTo(1));
        //     Assert.That(library.IsLoaned(movie), Is.True);
        //     Assert.That(library.UserHasDueLoans(user), Is.False);
        // }
        //
        // [Test]
        // public void LoanToUser_WithLoanedMovie_ThrowsException()
        // {
        //     var library = new MediaLibrary();
        //     var user1 = CreateUser("Usuario 1");
        //     var user2 = CreateUser("Usuario 2");
        //     var movie = CreateMovie();
        //     library.AddUser(user1);
        //     library.AddUser(user2);
        //     library.AddMovie(movie);
        //     library.LoanToUser(user1, movie);
        //
        //     Assert.That(() => library.LoanToUser(user2, movie),
        //         Throws.TypeOf<InvalidOperationException>());
        // }

        [Test]
        public void LoanToUser_WithTwoBooks_ThrowsException()
        {
            var library = new MediaLibrary();
            var user = CreateUser("");
            var book1 = CreateBook(title: "Libro 1", year: 2000);
            var book2 = CreateBook(title: "Libro 2", year: 2001);
            var book3 = CreateBook("Libro 3");
            library.AddUser(user);
            library.AddBook(book1);
            library.AddBook(book2);
            library.AddBook(book3);
            library.LoanToUser(user, book1);
            library.LoanToUser(user, book2);

            Assert.That(() => library.LoanToUser(user, book3),
                Throws.TypeOf<InvalidOperationException>());
        }

        [Test]
        public void UserHasDueLoans_WithoutLoans_ReturnsFalse()
        {
            var library = new MediaLibrary();
            var user = CreateUser();
            library.AddUser(user);

            Assert.That(library.UserHasDueLoans(user), Is.False);
            Assert.That(library.GetUserLoansCount(user), Is.EqualTo(0));
        }

        [Test]
        public void UserHasDueLoan_WithRecentLoan_ReturnsFalse()
        {
            var library = new MediaLibrary();
            var user = CreateUser();
            var book = CreateBook();
            library.AddUser(user);
            library.AddBook(book);

            library.LoanToUser(user, book, DateTime.Now);

            Assert.That(library.UserHasDueLoans(user), Is.False);
        }

        [Test]
        public void UserHasDueLoan_WithOldLoan_ReturnsTrue()
        {
            var library = new MediaLibrary();
            var user = CreateUser();
            var book = CreateBook();
            library.AddUser(user);
            library.AddBook(book);
            DateTime oldDate = DateTime.Now.AddDays(-book.LoanDays() - 1);

            library.LoanToUser(user, book, oldDate);

            Assert.That(library.UserHasDueLoans(user), Is.True);
        }
    }
}
