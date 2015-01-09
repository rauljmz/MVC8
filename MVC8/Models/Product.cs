using Sitecore.Mvc.Presentation;
using Sitecore.Web.UI.WebControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC8.Models
{
    public class Product : RenderingModel
    {
        public HtmlString Title
        {
            get
            {
                return new HtmlString(FieldRenderer.Render(Item, "title"));
            }
        }
        public HtmlString Description { get { return new HtmlString(FieldRenderer.Render(Item, "description")); } }
        public HtmlString Image { get { return new HtmlString(FieldRenderer.Render(Item, "image")); } }

        public HtmlString Price { get { return new HtmlString(FieldRenderer.Render(Item, "price"));  } }


    }
}