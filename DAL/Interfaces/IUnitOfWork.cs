namespace DAL.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IContactRepository ContactRepository { get; }

    int Complete();
}
