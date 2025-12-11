using System;

namespace Ucu.Poo.Library
{
    public class Loan
    {
        public User User { get; private set; }
        public Book Book { get; private set; }
        public DateTime LoanDate { get; private set; }
        
        public Loan(User user, Book book, DateTime loanDate)
        {
            this.User = user;
            this.Book = book;
            this.LoanDate = loanDate;
        }

        public bool IsDue()
        {
            DateTime dueDate = this.LoanDate.AddDays(this.Book.LoanDays());
            return DateTime.Now > dueDate;
        }
    }
}
