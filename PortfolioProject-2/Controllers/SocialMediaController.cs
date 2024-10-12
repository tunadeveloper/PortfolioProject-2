using PortfolioProject_2.Models.Entity;
using PortfolioProject_2.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortfolioProject_2.Controllers
{
    public class SocialMediaController : Controller
    {
        // GET: SocialMedia
        GenericRepository<SocialMedia> repo = new GenericRepository<SocialMedia>();

        public ActionResult Index()
        {
            var data = repo.List();
            return View(data);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(SocialMedia sM)
        {
            repo.TAdd(sM);
            return RedirectToAction("Index");
        }

        public ActionResult Update(int id) { 
        var socialMedia = repo.Find(x=> x.ID == id);
            return View(socialMedia);   
        }

        [HttpPost]
        public ActionResult Update(SocialMedia sM)
        {
            var socialMedia = repo.Find(x => x.ID == sM.ID);
            socialMedia.Name = sM.Name;
            socialMedia.Link = sM.Link;
            socialMedia.Icon = sM.Icon;
            socialMedia.Situation = true;
            repo.TUpdate(socialMedia);
            return RedirectToAction("Index");
        }

        public ActionResult SocialMediaPassive(int id)
        {
            var sM = repo.Find(x => x.ID == id);
            sM.Situation = false;
            repo.TUpdate(sM);
            return RedirectToAction("Index");
        }

        public ActionResult SocialMediaActive(int id) { 
        var sM = repo.Find(x => x.ID == id);
            sM.Situation = true;
            repo.TUpdate(sM);
            return RedirectToAction("Index");   
        }

    }
}