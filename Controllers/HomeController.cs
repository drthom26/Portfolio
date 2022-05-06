using ContactManagerAPP.V2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ContactManagerAPP.V2.Controllers
{
    public class HomeController : Controller
    {
       private ContactContext context { get; set; }
        public HomeController(ContactContext ctx)
        {
            context = ctx;
        }

        public IActionResult Index()
        {
            var contacts = context.Contacts
                .Include(c =>c.Category)
                .OrderBy(c =>c.FirstName).ToList();
            return View(contacts);
        }

           
       
    }
}
