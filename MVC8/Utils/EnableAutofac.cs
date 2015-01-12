namespace MVC8.Utils
{
    using Autofac;
    using Autofac.Integration.Mvc;
    using MVC8.Business;
    using Sitecore.Diagnostics;
    using Sitecore.Pipelines;
    using System.Web.Mvc;

    // TODO: \App_Config\include\EnableAutofac.config created automatically when creating EnableAutofac class.

    public class EnableAutofac
    {
        public void Process(PipelineArgs args)
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<FilteredNavigationBuilder>().As<INavigationBuilder>();
            builder.RegisterType<SitecoreItemRepository>().As<IItemRepository>();

            builder.RegisterControllers(this.GetType().Assembly);

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}