using MVC8.Models;
using MVC8.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC8.Controllers
{
    public class LoginCRController : Controller
    {
        // GET: LoginCR
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
                    return View("Success");

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