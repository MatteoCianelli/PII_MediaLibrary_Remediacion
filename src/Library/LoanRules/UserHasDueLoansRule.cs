using System;

namespace Ucu.Poo.Library
{
    public class UserHasDueLoansRule : ILoanRule
    {
        public UserHasDueLoansRule(MediaLibrary mediaLibrary, User user)
        {
            this.MediaLibrary = mediaLibrary;
            this.User = user;
        }
        
        public MediaLibrary MediaLibrary { get; private set; }
        public User User { get; private set; }

        public void ApplyRule()
        {
            if (this.MediaLibrary.UserHasDueLoans(this.User))
            {
                throw new InvalidOperationException(
                    $"El usuario {this.User.FullName} tiene préstamos vencidos.");
            }
        }
    }
}