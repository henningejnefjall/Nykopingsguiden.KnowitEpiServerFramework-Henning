using System;
using System.Collections.Generic;
using System.Linq;
using EPiServer.Cms.Shell;
using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using EPiServer.Shell;

namespace Knowit.EpiserverFramework.EpiCore.Features.PageTreeIcons
{
    /// <summary>
    /// Content type UI descrtiptor initialization
    /// Used to add custom content icons for the page tree.
    /// </summary>
    [InitializableModule]
    [ModuleDependency(typeof(InitializableModule))]
    public class PageTreeIconUiDescriptorInitialization : IInitializableModule
    {
        public void Initialize(InitializationEngine context)
        {
            var registry = context.Locate.Advanced.GetInstance<UIDescriptorRegistry>();
            var classes = GetDescriptorClasses(); // new Dictionary<Type, string>();
            
            foreach (var descriptor in registry.UIDescriptors)
            {
                if (classes.ContainsKey(descriptor.ForType))
                {
                    descriptor.IconClass += classes[descriptor.ForType];
                }
            }
        }

        public void Uninitialize(InitializationEngine context)
        {            
        }

        public void Preload(string[] parameters)
        {          
        }

        private static Dictionary<Type, string> GetDescriptorClasses()
        {
            var types = AppDomain.CurrentDomain.GetAssemblies().Where(a => a.FullName.Contains("Knowit.EpiserverFramework.Models")).SelectMany(ass => ass.GetTypes().Where(type => type.IsDefined(typeof(PageTreeIconAttribute), false)));

            var descriptors = from type in types select new { type, iconClass = ((PageTreeIconAttribute)Attribute.GetCustomAttribute(type, typeof(PageTreeIconAttribute))).IconClass };

            return descriptors.ToDictionary(key => key.type, value => value.iconClass);
        }
    }
}
