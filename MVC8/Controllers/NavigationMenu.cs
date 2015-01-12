using MVC8.Business;
using MVC8.Models;
using MVC8.Utils;
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
        protected IRenderingContext _renderingContext;

        public NavigationMenuController() 
        {

        }

        public NavigationMenuController(INavigationBuilder builder, IRenderingContext renderingContext)
        {
            _navigationBuilder = builder;
            _renderingContext = renderingContext;
        }
        // GET: Default
        public ActionResult Index()
        {
            var navigationItems = _navigationBuilder.NavigationForItem(_renderingContext.DatasourceGuid);

            return View(navigationItems);
        }
    }
}