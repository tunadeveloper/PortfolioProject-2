using PortfolioProject_2.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace PortfolioProject_2.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login
        MyPortfolioDb2Entities4 db = new MyPortfolioDb2Entities4();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Admin admin)
        {
            
            var userInfo = db.Admin.FirstOrDefault(x=>x.Username == admin.Username && x.Password == admin.Password);
            if (userInfo != null) {
                FormsAuthentication.SetAuthCookie(userInfo.Username, false);
                Session["Username"] = userInfo.Username.ToString();
                return RedirectToAction("Index", "About");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
            
        }

        public ActionResult LogOut() { 
        FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}