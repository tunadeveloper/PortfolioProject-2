using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PortfolioProject_2.Models.Entity;
using PortfolioProject_2.Repositories;

namespace PortfolioProject_2.Controllers
{
    public class SkillController : Controller
    {
        // GET: Skill

        GenericRepository<Skill> repo = new GenericRepository<Skill>();

        public ActionResult Index()
        {
            var skill = repo.List();
            return View(skill);
        }

        [HttpGet]
        public ActionResult AddSkill()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddSkill(Skill skill)
        {
            repo.TAdd(skill);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteSkill(int id)
        {
           var skill = repo.Find(x => x.Id == id);
            repo.TRemove(skill);
           return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpgradeSkill(int id)
        {
            var skill = repo.Find(x => x.Id == id);
            return View(skill);
        }
        [HttpPost]
        public ActionResult UpgradeSkill(Skill skill)
        {
            var s = repo.Find(x => x.Id == skill.Id);
            s.Skills = skill.Skills;
            s.Value = skill.Value;
            repo.TUpdate(skill);
            return RedirectToAction("Index");
        }
    }
}