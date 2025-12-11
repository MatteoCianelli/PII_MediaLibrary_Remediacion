using NUnit.Framework;

namespace Ucu.Poo.Library.Tests
{
    [TestFixture]
    public class MoviesRepositoryTests
    {
        private static Movie CreateMovie(string title = "El laberinto del fauno",
            string director = "Guillermo del Toro",
            int year = 2006, string imdbId = "tt0457430")
        {

            return new Movie(title, director, year, imdbId);
        }

        [Test]
        public void AddMovie_WithValidMovie_AddsToMovies()
        {
            MoviesRepository repository = new MoviesRepository();
            Movie movie = CreateMovie();

            repository.Add(movie);

            Assert.That(repository.Items.Count.Equals(1));
            Assert.That(repository.Items, Contains.Item(movie));
        }

        [Test]
        public void FindById_WithExistingId_ReturnsMovie()
        {
            MoviesRepository repository = new MoviesRepository();
            Movie movie = CreateMovie();
            repository.Add(movie);
            
            Movie actual = repository.FindById("tt0457430");

            Assert.That(actual, Is.EqualTo(movie));
        }

        [Test]
        public void FindById_WithNonExistingId_ReturnsNull()
        {
            MoviesRepository repository = new MoviesRepository();
            Movie movie = CreateMovie();
            repository.Add(movie);

            Movie actual = repository.FindById("tt0000000");

            Assert.That(actual, Is.Null);
        }
        
        [Test]
        public void FindByTitle_WithExistingTitle_ReturnsMovie()
        {
            MoviesRepository repository = new MoviesRepository();
            Movie movie = CreateMovie();
            repository.Add(movie);
            
            Movie actual = repository.FindByTitle("El laberinto del fauno");

            Assert.That(actual, Is.EqualTo(movie));
        }

        [Test]
        public void FindByTitle_WithNonExistingTitle_ReturnsNull()
        {
            MoviesRepository repository = new MoviesRepository();
            Movie movie = CreateMovie();
            repository.Add(movie);

            Movie actual = repository.FindByTitle("Ocho apellidos vascos");

            Assert.That(actual, Is.Null);
        }
    }
}
