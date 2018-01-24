using Sklep.Models.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sklep.Models.Attributes
{
    public class AuthorizeUser : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
             if (httpContext.Session["UserID"] != null)
             {
                 if (httpContext.Session["UserRole"].Equals("User") || httpContext.Session["UserRole"].Equals("Producer") || httpContext.Session["UserRole"].Equals("Admin"))
                 {
                     return true;
                 }
             }           
             return false;
        }
    }
}