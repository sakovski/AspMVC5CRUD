using Sklep.Models;
using Sklep.Models.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sklep.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            using(MyDbContext context = new MyDbContext())
            {
                return View(context.UserAccounts.ToList());
            }
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(ViewUserAccount viewAccount)
        {
            if(ModelState.IsValid)
            {
                UserAccount newAccount = new UserAccount() { FirstName = viewAccount.FirstName, LastName = viewAccount.LastName, Email = viewAccount.Email, Username = viewAccount.Username, Password = viewAccount.Password};
                using(MyDbContext context = new MyDbContext())
                {
                    var idRole = (from role in context.Roles where role.RoleName == RoleType.User select role.RoleID).FirstOrDefault();
                    newAccount.RoleId = idRole;
                    context.UserAccounts.Add(newAccount);
                    context.SaveChanges();
                }
                ModelState.Clear();
                ViewBag.Message = "Welcome " + viewAccount.FirstName + " " + viewAccount.LastName + "! You're succesfully registered!";
            }
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(ViewUserAccount account)
        {
            using (MyDbContext context = new MyDbContext())
            {
                var user = context.UserAccounts.Single(u => u.Username == account.Username && u.Password == account.Password);
                if(user != null)
                {
                    Session["UserID"] = user.UserID.ToString();
                    Session["UserName"] = user.Username.ToString();
                    return RedirectToAction("LoggedIn");
                }
                else
                {
                    ModelState.AddModelError("", "Username or password is wrong.");
                }
            }
            return View();
        }

        public ActionResult LoggedIn()
        {
            if (Session["UserID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }
    }
}