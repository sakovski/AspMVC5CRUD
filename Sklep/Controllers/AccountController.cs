using Sklep.Models;
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
                return View(context.userAccount.ToList());
            }
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(UserAccount account)
        {
            if(ModelState.IsValid)
            {
                using(MyDbContext context = new MyDbContext())
                {
                    context.userAccount.Add(account);
                    context.SaveChanges();
                }
                ModelState.Clear();
                ViewBag.Message = "Welcome " + account.FirstName + " " + account.LastName + "! You're succesfully registered!";
            }
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserAccount account)
        {
            using (MyDbContext context = new MyDbContext())
            {
                var user = context.userAccount.Single(u => u.Username == account.Username && u.Password == account.Password);
                if(user != null)
                {
                    Session["UserID"] = user.userID.ToString();
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
            return RedirectToAction("Index");
        }
    }
}