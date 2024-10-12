using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PortfolioProject_2.Models.Entity;
using PortfolioProject_2.Repositories;

namespace PortfolioProject_2.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        GenericRepository<Contact> repo = new GenericRepository<Contact>();
        public ActionResult Index()
        {
            var contact = repo.List();
            return View(contact);
        }
    }
}