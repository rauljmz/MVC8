using Sitecore.Data.Items;
using Sitecore.Links;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC8.Business
{
    public class SitecoreItem : IItem
    {
        public Item _item { get; private set; }
        public SitecoreItem()
        {

        }

        public SitecoreItem(Item item)
        {

        }
        public string Name
        {
            get
            {
                return _item.Name;
            }
            set
            {
                _item.Name = value;
            }
        }

        public string TemplateName
        {
            get
            {
                return _item.TemplateName;
            }
           
        }

        public string this[string fieldName]
        {
            get
            {
                return _item[fieldName];
            }
            set
            {
                _item[fieldName] = value;
            }
        }

        public string Url
        {
            get
            {
                return LinkManager.GetItemUrl(_item);
            }
        }
    }
}