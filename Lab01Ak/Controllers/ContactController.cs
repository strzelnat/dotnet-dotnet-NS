using Lab01Ak.Models;
using LaboratoriumASPNET.Models.Services;
using Microsoft.AspNetCore.Mvc;

namespace LaboratoriumASPNET.Controllers;

public class ContactController : Controller
{
    private readonly IContactService _contactService;

 
    public ContactController(IContactService contactService)
    {
        _contactService = contactService;
    }

 
    public IActionResult Index()
    {
        
        return View(_contactService.GetAll());
    }
    
   
    public IActionResult Add()
    {
        return View();
    }


    [HttpPost]
    public IActionResult Add(ContactModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }
        
        _contactService.Add(model);


        return RedirectToAction("Index");
    }


    public IActionResult Delete(int id)
    {
        _contactService.Delete(id);

 
        return RedirectToAction("Index");
    }
    
    public IActionResult ConfirmDelete(int id)
    {
        var contact = _contactService.GetById(id);
        if (contact == null)
        {
            return NotFound();
        }

        return View(contact);
    }


    [HttpPost]
    public IActionResult DeleteConfirmed(int id)
    {
        _contactService.Delete(id);
        return RedirectToAction("Index");
    }
    
    
 
    public IActionResult Details(int id)
    {
        var contact = _contactService.GetById(id);
        if (contact == null)
        {
            return NotFound();
        }
        return View(contact);
    }
    

    public IActionResult Edit(int id)
    {
        var contact = _contactService.GetById(id);
        if (contact == null)
        {
            return NotFound();
        }
        
        return View(contact);
    }

    // POST: Zapisz zmiany kontaktu
    [HttpPost]
    public IActionResult Edit(ContactModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }
        
        _contactService.Update(model);
        return RedirectToAction("Index");
    }
}
