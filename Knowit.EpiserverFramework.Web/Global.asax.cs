using System;
using System.Web.Mvc;
using System.Web.Optimization;
using Autofac;
using Autofac.Integration.Mvc;
using Knowit.EpiserverFramework.Web.ViewEngine;

namespace Knowit.EpiserverFramework.Web
{
    using EPiServer.Find;

    public class EPiServerApplication : EPiServer.Global
    {
        protected void Application_Start()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(EPiServerApplication).Assembly);
            builder.Register(x => CreateSearchClient()).As<IClient>().SingleInstance();

            var container = builder.Build();
            ////DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            AreaRegistration.RegisterAllAreas();
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            ViewEngineRegistration.Register(System.Web.Mvc.ViewEngines.Engines);
        }

        private static IClient CreateSearchClient()
        {
            var client = Client.CreateFromConfig();

            // Any modifications required goes here    
            return client;
        }
    }
}