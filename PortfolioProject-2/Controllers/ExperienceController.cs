using PortfolioProject_2.Models.Entity;
using PortfolioProject_2.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace PortfolioProject_2.Controllers
{
    
    public class ExperienceController : Controller
    {
        // GET: Experience
        ExperienceRepository repo = new ExperienceRepository();

        public ActionResult Index()
        {
            var experiences = repo.List();
            return View(experiences);
        }
        [HttpGet]
        public ActionResult AddExperience()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddExperience(Experience p)
        {
                repo.TAdd(p);
                return RedirectToAction("Index");
        }



        public ActionResult RemoveExperience(int id)
        {
            Experience t = repo.Find(x => x.Id == id);
            repo.TRemove(t);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateExperience(int id)
        {
            Experience t = repo.Find(x => x.Id == id);
            return View(t);
        }

        [HttpPost]
        public ActionResult UpdateExperience(Experience p)
        {
            Experience t = repo.Find(x => x.Id == p.Id);
            t.Position = p.Position;
            t.Description = p.Description;
            t.CompanyName = p.CompanyName;
            t.WorkDate = p.WorkDate;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}