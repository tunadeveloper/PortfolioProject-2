using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PortfolioProject_2.Models.Entity;
using PortfolioProject_2.Repositories;

namespace PortfolioProject_2.Controllers
{
    public class CertificateController : Controller
    {
        // GET: Certificate
        GenericRepository<Certificates> repository = new GenericRepository<Certificates>();
        public ActionResult Index()
        {
            var certificate = repository.List();
            return View(certificate);
        }

        public ActionResult UpdateCertificate(int id)
        {
            var certificates = repository.Find(x => x.Id == id);
            return View(certificates);
        }

        [HttpPost]
        public ActionResult UpdateCertificate(Certificates c)
        {
            var certificate = repository.Find(x=>x.Id == c.Id);
            certificate.Description = c.Description;
            certificate.Date = c.Date;
            repository.TUpdate(certificate);
            return RedirectToAction("Index");
        }

        public ActionResult AddCertificate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCertificate(Certificates c)
        {
            repository.TAdd(c);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteCertificate(int id)
        {

            var skill = repository.Find(x => x.Id == id);
            repository.TRemove(skill);
            return RedirectToAction("Index");
            
        }
    }
}