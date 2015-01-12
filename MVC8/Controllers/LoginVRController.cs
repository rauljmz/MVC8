using MVC8.Models;
using Sitecore.Mvc.Configuration;
using Sitecore.Mvc.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC8.Controllers
{
    public class LoginVRController : SitecoreController
    {
        [HttpPost]
        public ActionResult Login(LoginUser loginUser)
        {
            if (ModelState.IsValid)
            {
                if (Sitecore.Security.Authentication.AuthenticationManager.Login(loginUser.Username,loginUser.Password))
                {
                    return RedirectToRoute(MvcSettings.SitecoreRouteName, new { pathInfo = ""});

                }
                else
                {
                    ModelState.AddModelError("InvalidCredentials", "The credentials supplied are not correct.");
                }

            }
            return base.Index();
        }
    }
}