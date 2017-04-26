using System.Web.Mvc;
using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using EPiServer.ServiceLocation;
using EPiServer.Web.Mvc.Html;
using Knowit.EpiserverFramework.EpiCore.Features.DependencyInjection;
using StructureMap;

namespace Knowit.EpiserverFramework.EpiCore.Features.BlockHandling
{
    [InitializableModule]
    [ModuleDependency(typeof(EPiServer.Web.InitializationModule))]
    public class DependencyResolverInitialization : IConfigurableModule
    {
        public void ConfigureContainer(ServiceConfigurationContext context)
        {
            context.Container.Configure(ConfigureContainer);

            DependencyResolver.SetResolver(new StructureMapDependencyResolver(context.Container));
        }

        public void Initialize(InitializationEngine context)
        {
        }

        public void Uninitialize(InitializationEngine context)
        {
        }

        public void Preload(string[] parameters)
        {
        }

        private static void ConfigureContainer(ConfigurationExpression container)
        {
             //// container.For<ContentAreaRenderer>().Use<CustomContentAreaRenderer>();

            //// Implementations for custom interfaces can be registered here.
        }
    }
}
