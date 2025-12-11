using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Ucu.Poo.Library
{
    public class MediaLibrary
    {
        private List<User> users = new List<User>();
        private List<Loan> loans = new List<Loan>();
        private BooksRepository booksRepository = new BooksRepository();
        private MoviesRepository moviesRepository = new MoviesRepository();

        public IReadOnlyCollection<User> Users
        {
            get
            {
                return this.users.AsReadOnly();
            }
        }

        public IReadOnlyCollection<Loan> Loans
        {
            get
            {
                return this.loans.AsReadOnly();
            }
        }

        public void AddUser(User user)
        {
            ArgumentNullException.ThrowIfNull(user);

            if (this.FindUserByName(user.FullName) != null)
            {
                throw new InvalidOperationException(
                    $"Ya existe un usuario llamado '{user.FullName}'.");
            }

            this.users.Add(user);
        }
        
        public User FindUserByName(string name)
        {
            foreach (User user in users)
            {
                if (user.FullName == name)
                {
                    return user;
                }
            }

            return null;
        }

        public void AddBook(Book book)
        {
            this.booksRepository.Add(book);
        }

        public void AddMovie(Movie movie)
        {
            this.moviesRepository.Add(movie);
        }

        public Loan LoanToUser(User user, IMedia media, DateTime loanDate = default(DateTime))
        {
            ArgumentNullException.ThrowIfNull(user);
            ArgumentNullException.ThrowIfNull(media);
            
            // Regla para préstamo: no se puede prestar más de dos medios a un
            // mismo usuario a la vez.
            if (this.GetUserLoansCount(user) >= 2)
            {
                throw new InvalidOperationException(
                    $"El usuario {user.FullName} ya tiene dos préstamo activo.");
            }
            
            // Regla para préstamo: un medio no puede estar prestado a más de
            // un usuario a la vez.
            if (this.IsLoaned(media))
            {
                throw new InvalidOperationException(
                    $"El libro {media.Title} ya está prestado a otro usuario.");
            }
            
            // Regla para préstamo: un usuario con préstamos vencidos no puede
            // pedir nuevos préstamos.
            if (this.UserHasDueLoans(user))
            {
                throw new InvalidOperationException(
                    $"El usuario {user.FullName} tiene préstamos vencidos.");
            }
            
            if (loanDate == default(DateTime))
            {
                loanDate = DateTime.Now;
            }

            Loan loan = new Loan(user, media, loanDate);
            this.loans.Add(loan);
            return loan;
        }

        public bool UserHasDueLoans(User user)
        {
            foreach (Loan loan in this.loans)
            {
                if (loan.User == user && loan.IsDue())
                {
                    return true;
                }
            }

            return false;
        }

        public bool IsLoaned(IMedia media)
        {
            foreach (Loan loan in this.loans)
            {
                if (loan.Media == media)
                {
                    return true;
                }
            }

            return false;
        }
		
		public ReadOnlyCollection<Loan> GetUserLoans(User user)
        {
            List<Loan> result = new List<Loan>();
            foreach (Loan loan in this.loans)
            {
                if (loan.User == user)
                {
                    result.Add(loan);
                }
            }

            return result.AsReadOnly();
        }		

        public int GetUserLoansCount(User user)
        {
            return this.GetUserLoans(user).Count;
        }
    }
}
