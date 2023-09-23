using DAL.Entities;
using DAL.Interfaces;

namespace BL.Services;

public class ContactService : IService<Contact>
{
    private readonly IUnitOfWork _unitOfWork;

    public ContactService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public Contact AddContact(Contact contact)
    {
        var result = _unitOfWork.ContactRepository.Add(contact);
        if (result != null)
        {
            _unitOfWork.Complete();
            return contact;
        }
        return null;
    }

    public void DeleteContact(Guid id)
    {
        _unitOfWork.ContactRepository.Delete(id);
        _unitOfWork.Complete();
    }

    public Contact EditContact(Contact contact, bool resetLock = false)
    {
        if (resetLock)
        {
            contact.LockedBy = string.Empty;
        }
        var result = _unitOfWork.ContactRepository.Update(contact);
        if (result != null)
        {
            _unitOfWork.Complete();
            return contact;
        }
        return null;
    }

    public Contact GetByContactId(Guid id)
    {
        var contact = _unitOfWork.ContactRepository.GetById(id);
        if (contact != null)
        {
            _unitOfWork.Complete();
            return contact;
        }
        return null;
    }

    public IQueryable<Contact> ListAllContacts()
    {
        return _unitOfWork.ContactRepository.GetAll();
    }
}
