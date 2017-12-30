using Sklep.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sklep.Controllers
{
    public class ValidationController : Controller
    {
        private MyDbContext db = new MyDbContext();

        [HttpGet]
        public JsonResult IsEmailExist(string UserEmail)
        {  
            return Json(!db.UserAccounts.Any(x => x.Email.Equals(UserEmail)), JsonRequestBehavior.AllowGet);  
        }
           
        [HttpGet]
        public JsonResult IsUsernameExist(string Username)
        {  
            return Json(!db.UserAccounts.Any(x => x.Username.Equals(Username)), JsonRequestBehavior.AllowGet);             
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}