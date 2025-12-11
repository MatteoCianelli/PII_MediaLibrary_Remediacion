using System;
using NUnit.Framework;

namespace Ucu.Poo.Library.Tests
{
    public class MovieTests
    {
        [Test]
        public void Constructor_WithValidData_Succeeds()
        {
            var movie = new Movie(
                title: "El laberinto del fauno",
                year: 2006, 
                director: "Guillermo del Toro",
                imdbId: "tt0457430");

            Assert.That(movie, Is.Not.Null);
            Assert.That(movie.Title, Is.EqualTo("El laberinto del fauno"));
            Assert.That(movie.Year, Is.EqualTo(2006));
            Assert.That(movie.Director, Is.EqualTo("Guillermo del Toro"));
            Assert.That(movie.ImdbId, Is.EqualTo("tt0457430"));
        }
        
        [Test]
        public void Constructor_WithInvalidYear_ThrowsException()
        {
            Assert.That(() => new Movie(
                title: "El laberinto del fauno",
                year: 1887, 
                director: "Guillermo del Toro",
                imdbId: "tt0457430"), Throws.TypeOf<ArgumentException>());
        }

        [Test]
        public void LoadDays_Returns_7()
        {
            var movie = new Movie(
                title: "El laberinto del fauno",
                year: 2006, 
                director: "Guillermo del Toro",
                imdbId: "tt0457430");
            
            Assert.That(movie.LoanDays(), Is.EqualTo(7));
        }

        [Test]
        public void Describe_ReturnsFormattedText()
        {
            var movie = new Movie(
                title: "El laberinto del fauno",
                year: 2006, 
                director: "Guillermo del Toro",
                imdbId: "tt0457430");
            
            var expected = movie.Describe();

            Assert.That(expected, Is.EqualTo(
                "Movie: El laberinto del fauno (2006), directed by: Guillermo del Toro; IMDB Id tt0457430"));
        }

    }
}
