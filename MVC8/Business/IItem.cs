using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC8.Business
{
    public interface IItem
    {
        string Name { get; set; }
        string TemplateName { get;  }

        string this[string fieldName] { get; set; }

        string Url { get; }
    }
}
