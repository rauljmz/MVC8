using MVC8.Models;
using Sitecore.Data.Items;
using Sitecore.Links;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC8.Business
{
    public class NavigationBuilder : INavigationBuilder
    {

        public virtual IEnumerable<NavigationItem> NavigationForItem(string pathOrId)
        {
            var navigationItems = new List<NavigationItem>();
            var home = Sitecore.Context.Database.GetItem(Sitecore.Context.Site.StartPath);
            
            navigationItems.Add(CreateNavigationItemFromItem(home,"HOME"));

            navigationItems.AddRange(home.GetChildren().Select(i=> CreateNavigationItemFromItem(i)));
            
            return navigationItems;
        }

        private NavigationItem CreateNavigationItemFromItem(Item item, string navigationtitle = "")
        {
            return new NavigationItem()
            {
                Url = LinkManager.GetItemUrl(item),
                NavigationTitle = Sitecore.StringUtil.GetString(navigationtitle, item["title"],item.Name)
            };
        }


    }
}