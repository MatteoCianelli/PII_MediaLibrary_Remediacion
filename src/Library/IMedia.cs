namespace Ucu.Poo.Library
{
    public interface IMedia
    {
        string Title { get; set; }
        int Year { get; set; }
        
        int LoanDays();

        string Describe();
        
        bool CheckId(string id);

    }
}