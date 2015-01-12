namespace MVC8.Utils
{
    using Sitecore.Diagnostics;
    using Sitecore.Pipelines;
    using System.Web.Routing;

    // TODO: \App_Config\include\LoadRoutes.config created automatically when creating LoadRoutes class.

    public class LoadRoutes
    {
        public void Process(PipelineArgs args)
        {
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}