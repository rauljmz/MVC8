using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC8.Business
{
    public interface IItemRepository
    {
        IItem GetItem(string idOrPath);
        IEnumerable<IItem> GetChildren(string idOrPath);
        IEnumerable<IItem> GetChildren(IItem item);

    }
}
