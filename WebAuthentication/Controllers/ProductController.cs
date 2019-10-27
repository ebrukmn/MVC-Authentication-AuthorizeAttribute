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
    [EmployeeAuthentication(Roles = "Admin")]
    public class ProductController : Controller
    {
        NorthwindEntities db = DBTool.DBInstance;

        public ActionResult DeleteProduct(int id)
        {
            db.Products.Remove(db.Products.Find(id));
            db.SaveChanges();
            return RedirectToAction("ListProducts", "ListProducts");
        }

        public ActionResult UpdateProduct(int id)
        {
            return View(Tuple.Create(db.Categories.ToList(),db.Products.Find(id)));
        }

        [HttpPost]
        public ActionResult UpdateProduct([Bind(Prefix ="Item2")]Product item)
        {
            Product ToBeUpdated = db.Products.Find(item.ProductID);
            db.Entry(ToBeUpdated).CurrentValues.SetValues(item);
            db.SaveChanges();
            return RedirectToAction("ListProducts", "ListProducts");
        }
    }
}