using DAL.Data;
using DAL.Interfaces;
using DAL.Repositories;

namespace DAL;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;
    public IContactRepository ContactRepository { get; }

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
        ContactRepository = new ContactRepository(_context);
    }
    public int Complete()
    {
        return _context.SaveChanges();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
