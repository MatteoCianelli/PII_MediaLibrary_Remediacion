using System;

namespace Ucu.Poo.Library
{
    public class LoanCountRule : ILoanRule
    {
        public LoanCountRule(MediaLibrary mediaLibrary, User user)
        {
            this.MediaLibrary = mediaLibrary;
            this.User = user;
        }
        
        public MediaLibrary MediaLibrary { get; private set; }
        public User User { get; private set; }

        public void ApplyRule()
        {
            if (this.MediaLibrary.GetUserLoansCount(this.User) >= 2)
            {
                throw new InvalidOperationException(
                    $"El usuario {this.User.FullName} ya tiene dos préstamo activo.");
            }
        }
    }
}