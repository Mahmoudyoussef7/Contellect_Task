using App.Custom;
using App.Hubs;
using BL.Services;
using BL.ViewModels;
using DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace App.Controllers;

[UserAuth]
public class ContactController : Controller
{
    private readonly IService<Contact> _contactService;
    private readonly IHubContext<ContactHub> _hubContext;

    public ContactController(IService<Contact> service, IHubContext<ContactHub> hubContext)
    {
        _contactService = service;
        _hubContext = hubContext;
    }
    public ActionResult Index(int pageNumber = 1)
    {
        return View(GetPagedContacts(_contactService.ListAllContacts(), pageNumber));
    }

    [HttpGet]
    public ActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Contact contact)
    {
        Contact result = new Contact();
        if (ModelState.IsValid)
        {
            result =_contactService.AddContact(contact);
            return RedirectToAction(nameof(Index));
        }

        return View(result);
    }

    [HttpPost]
    public IActionResult Edit(Contact contact)
    {
        if (ModelState.IsValid)
        {
            try
            {
                if (contact.LockedBy != string.Empty && contact.LockedBy != Request.Cookies["UserName"])
                {
                    return NotFound("The contact already locked");
                }
                _contactService.EditContact(contact, true);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (_contactService.GetByContactId(contact.Id) == null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(Guid id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var contact = _contactService.GetByContactId(id);
            
        if (contact == null)
        {
            return NotFound();
        }

        return View(contact);
    }

    [HttpGet, ActionName("DeleteContact")]
    public async Task<IActionResult> DeleteConfirmed(Guid id)
    {
        _contactService.DeleteContact(id);
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public IActionResult LockContactAsync(Guid id)
    {
        var contact = _contactService.GetByContactId(id);
        if (contact == null)
        {
            return NotFound();
        }
        contact.LockedBy = Request.Cookies["UserName"];
        _contactService.EditContact(contact);

        // Notify clients about the updated contact
        //await _hubContext.Clients.All.SendAsync("ContactLocked", contact.Id);

        return Ok();
    }

    private PagedContactsVM GetPagedContacts(IQueryable<Contact> contacts,int pageNumber = 1)
    {
        const int pageSize = 5;
        int totalContacts = contacts.Count();
        int totalPages = (int)Math.Ceiling((double)totalContacts / pageSize);
        return new PagedContactsVM
        {
            Contacts = contacts.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList(),
            CurrentPage = pageNumber,
            TotalPages = totalPages
        };
    }

}
