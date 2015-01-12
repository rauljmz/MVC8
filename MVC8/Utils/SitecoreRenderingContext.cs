using Sitecore.Mvc.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC8.Utils
{
    public class SitecoreRenderingContext : IRenderingContext
    {
        public string DatasourceGuid
        {
            get
            {
                return RenderingContext.Current.Rendering.Item.ID.ToString();
            }
        }
    }
}