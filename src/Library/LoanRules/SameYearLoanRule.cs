using System;
using System.Collections.Generic;

namespace Ucu.Poo.Library
{
    public class SameYearLoanRule : ILoanRule
    {
        public SameYearLoanRule(MediaLibrary mediaLibrary, User user, IMedia media)
        {
            this.MediaLibrary = mediaLibrary;
            this.User = user;
            this.Media = media;
        }
        
        public MediaLibrary MediaLibrary { get; private set; }
        public User User { get; private set; }
        public IMedia Media { get; private set; }
        
        public void ApplyRule()
        {
            IReadOnlyList<Loan> userLoans = this.MediaLibrary.GetUserLoans(User);
            foreach (var loan in userLoans)
            {
                if (loan.MediaYear() == this.Media.Year)
                {
                    throw new InvalidOperationException(
                        $"El usuario {this.User.FullName} ya tiene un prestamos de ese año.");
                }
            }
        }
    }
}