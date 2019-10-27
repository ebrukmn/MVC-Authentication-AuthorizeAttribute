using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAuthentication.Models;
using WebAuthentication.SingletonPattern;

namespace WebAuthentication.Controllers
{
    public class HomeController : Controller
    {
        NorthwindEntities db = DBTool.DBInstance;

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost] 
        public ActionResult Login(Employee item)
        {
            if(db.Employees.Any(x=>x.FirstName==item.FirstName&&x.LastName==item.LastName))
            {
                Session["User"] = db.Employees.Where(x=>x.FirstName==item.FirstName).Single();
                return RedirectToAction("ListProducts", "ListProducts");
            }
            return RedirectToAction("Login");
        }
        public ActionResult Logout()
        {
            Session.Remove("User");
            return RedirectToAction("Login", "Home");
        }
    }
}