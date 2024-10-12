using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PortfolioProject_2.Models.Entity;

namespace PortfolioProject_2.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        // GET: Default
        MyPortfolioDb2Entities4 db = new MyPortfolioDb2Entities4();
        public ActionResult Index()
        {
            var values = db.About.ToList();
            return View(values);
        }

        public PartialViewResult Experience()
        {
            var experinces= db.Experience.ToList();
            return PartialView(experinces);
        }

        public PartialViewResult Education()
        {
            var educations = db.Education.ToList();
            return PartialView(educations);
        }
        public PartialViewResult SocialMedia()
        {
            var socialMedia = db.SocialMedia.Where(x=>x.Situation == true).ToList();
            return PartialView(socialMedia);
        }

        public PartialViewResult Skill()
        {
            var skills = db.Skill.ToList();
            return PartialView(skills);
        }

        public PartialViewResult Interest() {
            
            var inretests = db.Interests.ToList();
            return PartialView(inretests);
        }

        public PartialViewResult Certificate()
        {
            var certificates = db.Certificates.ToList();
            return PartialView(certificates);
        }

        [HttpGet]
        public PartialViewResult Contact() {

            return PartialView();
        }
        [HttpPost]
        public PartialViewResult Contact(Contact contact)
        {
            contact.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.Contact.Add(contact);
            db.SaveChanges();
            return PartialView();
        }
    }
}