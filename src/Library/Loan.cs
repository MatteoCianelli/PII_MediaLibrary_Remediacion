using System;

namespace Ucu.Poo.Library
{
    public class Loan
    {
        public User User { get; private set; }
        public IMedia Media { get; private set; }
        public DateTime LoanDate { get; private set; }
        
        public Loan(User user, IMedia media, DateTime loanDate)
        {
            this.User = user;
            this.Media = media;
            this.LoanDate = loanDate;
        }

        public bool IsDue()
        {
            DateTime dueDate = this.LoanDate.AddDays(this.Media.LoanDays());
            return DateTime.Now > dueDate;
        }

        public int MediaYear()
        {
            return Media.Year;
        }
    }
}
