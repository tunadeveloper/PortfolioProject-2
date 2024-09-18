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
    }
}