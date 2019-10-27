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
    [EmployeeAuthentication(Roles = "Moderator,Admin,User")]
    public class ListProductsController : Controller
    {
        NorthwindEntities db = DBTool.DBInstance;

        public ActionResult ListProducts()
        {
            return View(db.Products.ToList());
        }
    }
}