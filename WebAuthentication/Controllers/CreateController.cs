using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAuthentication.AuthEmployee;
using WebAuthentication.Models;
using WebAuthentication.SingletonPattern;

namespace WebAuthentication.Controllers
{
    [EmployeeAuthentication(Roles = "Moderator,Admin")]
    public class CreateController : Controller
    {
        NorthwindEntities db = DBTool.DBInstance;

        public ActionResult AddProduct()
        {
            return View(Tuple.Create(db.Categories.ToList(), new Product()));
        }

        [HttpPost]
        public ActionResult AddProduct([Bind(Prefix = "Item2")]Product item)
        {
            db.Products.Add(item);
            db.SaveChanges();
            return RedirectToAction("ListProducts", "ListProducts");
        }
    }
}