using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC8.Business
{
    public class FilteredNavigationBuilder : NavigationBuilder
    {
        public override IEnumerable<Models.NavigationItem> NavigationForItem(string pathOrId)
        {
            return base.NavigationForItem(pathOrId).Where(n => n.NavigationTitle != "$name");
        }
    }
}