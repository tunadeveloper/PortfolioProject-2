using PortfolioProject_2.Models.Entity;
using PortfolioProject_2.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortfolioProject_2.Controllers
{
    public class InterestsController : Controller
    {
        // GET: Interests
        GenericRepository<Interests> repo = new GenericRepository<Interests>();

        [HttpGet]
        public ActionResult Index()
        {
            var interests = repo.List();
            return View(interests);
        }

        [HttpPost]
        public ActionResult Index(Interests interests)
        {
            var value = repo.Find(x=>x.Id == 1);
            value.Description = interests.Description;
            value.Description2 = interests.Description2;
            repo.TUpdate(value);
            return RedirectToAction("Index");
        }
    }
}