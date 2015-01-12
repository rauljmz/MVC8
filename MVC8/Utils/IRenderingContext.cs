using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC8.Utils
{
    public interface IRenderingContext
    {
        string DatasourceGuid { get; }
    }
}
