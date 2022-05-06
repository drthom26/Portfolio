using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ContactManagerAPP.V2.Models;

namespace ContactManagerAPP.V2.Controllers
{
    public class ContactController : Controller
    {
        private ContactContext context { get; set; }
        public ContactController(ContactContext ctx)
        {
            context = ctx;
        }
        public IActionResult Details(int id)
        {
            var contact = context.Contacts
                .Include(c => c.Category)
                .FirstOrDefault(c => c.ContactId == id);
            return View(contact);
        }
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.action = "Add";
            ViewBag.Categories = context.Categories.OrderBy(c => c.Name).ToList();
            return View("Edit", new Contact());
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.action = "Edit";
            ViewBag.Categories = context.Categories.OrderBy(c =>c.Name).ToList();

            var contact = context.Contacts
                .Include(c => c.Category)
                .FirstOrDefault(c => c.ContactId == id);
            return View(contact);
        }
        [HttpPost]
        public IActionResult Edit(Contact contact)
        {
            if (ModelState.IsValid)
            {
                if (contact.ContactId == 0)
                    context.Contacts.Add(contact);
                else
                    context.Contacts.Update(contact);
                context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Action = (contact.ContactId == 0) ? "Add" : "Edit";
                ViewBag.Categories = context.Categories.OrderBy(c =>c.Name).ToList();
                return View(contact);
            }
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var contact = context.Contacts
                .Include(c => c.Category)
                .FirstOrDefault(c => c.ContactId == id);
            return View(contact);
        }
        [HttpPost]
        public IActionResult Delete(Contact contact)
        {
            context.Contacts.Update(contact);
            context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}
