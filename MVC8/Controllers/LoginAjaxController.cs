using MVC8.Models;
using MVC8.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC8.Controllers
{
    public class LoginAjaxController : Controller
    {
        // GET: LoginAjax
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        [ValidateFormHandler]
        public ActionResult Index(LoginUser loginUser)
        {
            if (ModelState.IsValid)
            {
                if (Sitecore.Security.Authentication.AuthenticationManager.Login(loginUser.Username, loginUser.Password))
                {
                    Sitecore.Analytics.Tracker.Current.CurrentPage.Register("login", "user has login");    
                    return View("Success");
                    //return Content("<div>Success!</div>");
                }
                else
                {
                    ModelState.AddModelError("InvalidCredentials", "The credentials supplied are not correct.");
                }

            }
            return View(loginUser);
        }
    }
}