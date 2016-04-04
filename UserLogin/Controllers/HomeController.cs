using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Authentication.Data;
using MvcApplication14.Models;


namespace MvcApplication14.Controllers
{
    public class UserViewModel
    {
        public string Name { get; set; }
    }



    public class HomeController : Controller
    {
        public ActionResult Signup()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Signup(string username, string name, string password)
        {
            var mgr = new UserManager(Properties.Settings.Default.ConStr);
            mgr.AddUser(username, password, name);


            return RedirectToAction("Signin");
        }



        public ActionResult Signin()
        {
            return View(new UserViewModel());
        }


        [HttpPost]
        public ActionResult Signin(string username, string password)
        {
            var mgr = new UserManager(Properties.Settings.Default.ConStr);
            var user = mgr.GetUser(username, password); if (user == null)
            {
                return View(new UserViewModel { Name = username });
            }


            FormsAuthentication.SetAuthCookie(user.UserName, true);
            return RedirectToAction("Private");
        }

        [Authorize]
        public ActionResult Private()
        {
            return View();
        }

        public ActionResult Signout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Signin");
        }


    }
}

