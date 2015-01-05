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
        // GET: Default
        public ActionResult Index()
        {
            var homeItem = Sitecore.Context.Database.GetItem(Sitecore.Context.Site.StartPath);

            var navigationItems = new List<NavigationItem>();

            navigationItems.Add(new NavigationItem() { NavigationTitle = "Home", Url = "/" });

           navigationItems.AddRange(homeItem.Children
                .Where(i=> i.Template.Key == "product")
                .Select(i=> new NavigationItem(){
                    NavigationTitle = i.Name,
                    Url = LinkManager.GetItemUrl(i)
                }));
     
            
            return View(navigationItems);
        }
    }
}