using MVC8.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC8.Business
{
    public class NavigationBuilder : INavigationBuilder
    {
        public IItemRepository _itemRepository { get; set; }

        public NavigationBuilder(IItemRepository itemRepostory)
        {
            _itemRepository = itemRepostory;
        }


        public virtual IEnumerable<NavigationItem> NavigationForItem(string pathOrId)
        {
            var navigationItems = new List<NavigationItem>();
            var home = _itemRepository.GetItem(pathOrId);

            if (home != null)
            {
                navigationItems.Add(CreateNavigationItemFromItem(home, "HOME"));

                navigationItems.AddRange(_itemRepository.GetChildren(home).Select(i => CreateNavigationItemFromItem(i)));
            }

            return navigationItems;
        }

        private NavigationItem CreateNavigationItemFromItem(IItem item, string navigationtitle = "")
        {
            return new NavigationItem()
            {
                Url = item.Url,
                NavigationTitle = new [] {navigationtitle, item["title"], item.Name}.FirstOrDefault(st=> !string.IsNullOrWhiteSpace(st))
            };
        }


    }
}