using DAL.Entities;

namespace BL.ViewModels;

public class PagedContactsVM
{
    public List<Contact> Contacts { get; set; } = new List<Contact>();
    public int TotalPages { get; set; }
    public int CurrentPage { get; set; }
}
