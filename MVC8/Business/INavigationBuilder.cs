using MVC8.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVC8.Business
{
    public interface INavigationBuilder
    {
        IEnumerable<NavigationItem> NavigationForItem(string pathOrId);
    }
}
