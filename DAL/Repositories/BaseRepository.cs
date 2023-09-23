using DAL.Data;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DAL.Repositories;

public class BaseRepository<T> : IRepository<T> where T : class
{
    protected ApplicationDbContext _context;
    protected DbSet<T> DbSet { get; set; }

    public BaseRepository(ApplicationDbContext context)
    {
        _context = context;
        DbSet = _context.Set<T>();
    }

    public virtual T Add(T entity)
    {
        DbSet.Add(entity);
        return entity;
    }

    public virtual void Delete(Guid id)
    {
        var entity = DbSet.Find(id);
        if (entity != null)
        {
            DbSet.Remove(entity);
        }
    }

    public virtual IQueryable<T> GetAll()
    {
        return DbSet;
    }

    public virtual T GetById(Guid id)
    {
        return DbSet.Find(id);
    }

    public virtual IQueryable<T> GetByExpression(Expression<Func<T, bool>> criteria)
    {
        var result = DbSet.Where(criteria);
        return result;
    }

    public virtual T Update(T entity)
    {
        if (entity != null)
        {
            DbSet.Update(entity);
            return entity;
        }
        return null;
    }

    public IQueryable<T> Search(string str)
    {
        throw new NotImplementedException();
    }
}
