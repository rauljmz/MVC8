using Sitecore.Data;
using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC8.Business
{
    public class SitecoreItemRepository : IItemRepository
    {
        private Database _database;
        public SitecoreItemRepository()
        {
            _database = Sitecore.Context.Database;
        }

        public SitecoreItemRepository(Database database)
        {
            _database = database;
        }
        private Item GetItemInternal(string idOrPath)
        {
            return _database.GetItem(idOrPath);
        }
        public IItem GetItem(string idOrPath)
        {
            return new SitecoreItem(GetItemInternal(idOrPath));
        }

        public IEnumerable<IItem> GetChildren(IItem item)
        {
            var sitecoreItem = item as SitecoreItem;

            return sitecoreItem._item.GetChildren().Select(i => new SitecoreItem(i));
        }


        IEnumerable<IItem> IItemRepository.GetChildren(string idOrPath)
        {
            return GetItemInternal(idOrPath).GetChildren().Select(i => new SitecoreItem(i));
        }
    }
}