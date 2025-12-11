namespace Ucu.Poo.Library
{
    public interface IRepository
    {
        IMedia FindById(string id);

        IMedia FindByTitle(string title);

        void Add(IMedia media);
    }
}