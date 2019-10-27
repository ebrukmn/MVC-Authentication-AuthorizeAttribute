using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAuthentication.Models;

namespace WebAuthentication.AuthEmployee
{
    public class EmployeeAuthentication:AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            Employee user = httpContext.Session["User"] as Employee;
            var r=Roles.Split(',');

            if (user.RolesID==1)
            {
                if (r.Contains("Admin"))
                {
                    return true;
                }
            }
            if (user.RolesID==2)
            {
                if (r.Contains("Moderator"))
                {
                    return true;
                }
            }
            if (user.RolesID==3)
            {
                if (r.Contains("User"))
                {
                    return true;
                }
            }
            return base.AuthorizeCore(httpContext);
        }
    }
}