//--------------------------------------------------------------------------------
// <copyright file="Program.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------

using System;

namespace Ucu.Poo.Library
{
    /// <summary>
    /// Programa de consola de demostración.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// Punto de entrada al programa principal.
        /// </summary>
        public static void Main()
        {
            MediaLibrary library = new MediaLibrary();

            Book book = new Book(
                title: "Cien años de soledad",
                year: 1967,
                author: "Gabriel García Márquez",
                isbn: "978-8497592208"
            );
            library.AddBook(book);
            Console.WriteLine(book.Describe());

            book = new Book(
                title: "Martín Fierro",
                year: 1872,
                author: "José Hernández",
                isbn: "978-9871138763"
            );
            library.AddBook(book);
            Console.WriteLine(book.Describe());

            Movie movie = new Movie(
                title: "El laberinto del fauno",
                year: 2006,
                director: "Guillermo del Toro",
                imdbId: "tt0457430"
            );
            library.AddMovie(movie);
            Console.WriteLine(movie.Describe());

            movie = new Movie(
                title: "Amores perros",
                year: 2000,
                director: "Alejandro González Iñárritu",
                imdbId: "tt0245712"
            );
            library.AddMovie(movie);
            Console.WriteLine(movie.Describe());

            User user = new User("Ana Pérez");
            library.AddUser(user);

            library.LoanToUser(user, book);
        }
    }
}