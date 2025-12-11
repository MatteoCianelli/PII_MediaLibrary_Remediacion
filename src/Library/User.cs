namespace Ucu.Poo.Library
{
    public class User
    {
        public User(string fullName)
        {
            this.FullName = fullName;
        }
        
        public string FullName { get; private set; }
    }
}
