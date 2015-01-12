using MVC8.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC8.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            var product = new Product();
            product.Item = Sitecore.Mvc.Presentation.PageContext.Current.Item;

            return View(product);
        }
    }
}