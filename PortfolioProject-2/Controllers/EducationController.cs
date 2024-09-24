using PortfolioProject_2.Models.Entity;
using PortfolioProject_2.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortfolioProject_2.Controllers
{
    public class EducationController : Controller
    {
        // GET: Education
        GenericRepository<Education> repo = new GenericRepository<Education>();
        public ActionResult Index()
        {
            var education = repo.List();
            return View(education);
        }

        [HttpGet]
        public ActionResult AddEducation()
        {
            return View();
        }


        [HttpPost]
        public ActionResult AddEducation(Education education)
        {
            if (!ModelState.IsValid) { 
            return View("AddEducation");
            }
            repo.TAdd(education);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateEducation(int id) {

            Education e = repo.Find(x => x.Id == id);
        return View(e);
        }

        [HttpPost]  
        public ActionResult UpdateEducation(Education e)
        {
            if (!ModelState.IsValid)
            {
                return View("UpdateEducation");
            }
            var education = repo.Find(x => x.Id == e.Id);
            education.UniversityName = e.UniversityName;
            education.TrainingName = e.TrainingName;
            education.Description = e.Description;
            education.Agno = e.Agno;
            education.EducationDate = e.EducationDate;
            repo.TUpdate(education);
            return RedirectToAction("Index");
        }


        public ActionResult RemoveEducation(int id)
        {
            Education e = repo.Find(x => x.Id == id);
            repo.TRemove(e);
            return RedirectToAction("Index");
        }
    }
}





