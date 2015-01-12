using MVC8.Business;
using MVC8.Models;
using Sitecore.Links;
using Sitecore.Mvc.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC8.Controllers
{
    public class NavigationMenuController : Controller
    {
        protected INavigationBuilder _navigationBuilder;

        public NavigationMenuController() : this(new NavigationBuilder())
        {

        }

        public NavigationMenuController(INavigationBuilder builder)
        {
            _navigationBuilder = builder;
        }
        // GET: Default
        public ActionResult Index()
        {
            var navigationItems = _navigationBuilder.NavigationForItem(RenderingContext.Current.Rendering.Item.ID.ToString());

            return View(navigationItems);
        }
    }
}