using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC8.Utils
{
    public class ValidateFormHandler : ActionMethodSelectorAttribute
    {

        public override bool IsValidForRequest(ControllerContext controllerContext, System.Reflection.MethodInfo methodInfo)
        {
            var scController = string.Concat(controllerContext.HttpContext.Request.Form["_controller"],"Controller");
            if(scController != methodInfo.DeclaringType.Name) return false;
            return controllerContext.HttpContext.Request.Form["_action"] == methodInfo.Name;
        }
    }
}