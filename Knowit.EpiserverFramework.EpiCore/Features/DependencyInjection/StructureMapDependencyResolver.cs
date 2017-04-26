using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using StructureMap;

namespace Knowit.EpiserverFramework.EpiCore.Features.DependencyInjection
{
    /// <summary>
    /// Structure map dependency resolver
    /// Page type handling in constructor
    /// </summary>
    public class StructureMapDependencyResolver : IDependencyResolver
    {
        private readonly IContainer container;

        public StructureMapDependencyResolver(IContainer container)
        {
            this.container = container;
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return this.container.GetAllInstances(serviceType).Cast<object>();
        }

        public object GetService(Type serviceType)
        {
            if (serviceType.IsInterface || serviceType.IsAbstract)
            {
                return GetInterfaceService(serviceType);
            }

            return GetConcreteService(serviceType);
        }

        private object GetConcreteService(Type serviceType)
        {
            try
            {
                // Can't use TryGetInstance here because it won’t create concrete types
                return container.GetInstance(serviceType);
            }
            catch (StructureMapException)
            {
                return null;
            }
        }

        private object GetInterfaceService(Type serviceType)
        {
            return container.TryGetInstance(serviceType);
        }
    }
}
