using PortfolioProject_2.Models.Entity;
using PortfolioProject_2.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortfolioProject_2.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        MyPortfolioDb2Entities4 db = new MyPortfolioDb2Entities4();
        GenericRepository<About> repo = new GenericRepository<About>();
        [HttpGet]
        public ActionResult Index()
        {
            var about = repo.List();
            return View(about);
        }

        [HttpPost]
        public ActionResult Index(About about)
        {
            var value = repo.Find(x => x.Id == 1);
            value.Name = about.Name;
            value.Surname = about.Surname;
            value.Address = about.Address;
            value.Email = about.Email;
            value.PhoneNumber = about.PhoneNumber;
            value.Description = about.Description;
            value.Image = about.Image;
            repo.TUpdate(value);
            return RedirectToAction("Index");
        }
    }
}