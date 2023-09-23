namespace BL.Services;

public interface IService<T> where T : class
{
    IQueryable<T> ListAllContacts();
    T AddContact(T entity);
    T EditContact(T entity, bool resetLock = false);
    void DeleteContact(Guid id);
    T GetByContactId(Guid id);
}
