using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC8.Controllers
{
    public class SessionController : Controller
    {
        // GET: Session
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Abandon()
        {
            Session.Abandon();
            return View("Index");
        }
    }
}