using System.Web.Mvc;
using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using EPiServer.Framework.Localization;
using EPiServer.ServiceLocation;
using EPiServer.Web;

namespace Knowit.EpiserverFramework.EpiCore.Features.BlockHandling
{
    [InitializableModule]
    [ModuleDependency(typeof(EPiServer.Web.InitializationModule))]
    public class DisplayRegistryInitialization : IInitializableModule
    {
        public void Initialize(InitializationEngine context)
        {
            if (context.HostType == HostType.WebApplication)
            {
                // Register Display Options
                //// TODO: Fix order without Description
                var options = ServiceLocator.Current.GetInstance<DisplayOptions>();
                options
                    .Add(new DisplayOption
                    {
                        Id = EpiCoreConstants.ContentAreaIds.Full,
                        Name = LocalizationService.Current.GetString(EpiCoreTranslations.DisplayOptions.Full),
                        Tag = EpiCoreConstants.ContentAreaTags.FullWidth,
                        IconClass = EpiCoreConstants.EpiserverIconClass.Full,
                        Description = EpiCoreConstants.ContentAreaWidths.Full.ToString()
                    })
                    .Add(new DisplayOption
                    {
                        Id = EpiCoreConstants.ContentAreaIds.ThreeQuarters,
                        Name = LocalizationService.Current.GetString(EpiCoreTranslations.DisplayOptions.ThreeQuarters),
                        Tag = EpiCoreConstants.ContentAreaTags.ThreeQuarters,
                        IconClass = EpiCoreConstants.EpiserverIconClass.ThreeQuarters,
                        Description = EpiCoreConstants.ContentAreaWidths.ThreeQuarters.ToString()
                    })
                    .Add(new DisplayOption
                    {
                        Id = EpiCoreConstants.ContentAreaIds.Half,
                        Name = LocalizationService.Current.GetString(EpiCoreTranslations.DisplayOptions.Half),
                        Tag = EpiCoreConstants.ContentAreaTags.Half,
                        IconClass = EpiCoreConstants.EpiserverIconClass.Half,
                        Description = EpiCoreConstants.ContentAreaWidths.Half.ToString()
                    })
                    .Add(new DisplayOption
                     {
                         Id = EpiCoreConstants.ContentAreaIds.Quarter,
                         Name = LocalizationService.Current.GetString(EpiCoreTranslations.DisplayOptions.Quarter),
                         Tag = EpiCoreConstants.ContentAreaTags.Quarter,
                         IconClass = EpiCoreConstants.EpiserverIconClass.Quarter,
                         Description = EpiCoreConstants.ContentAreaWidths.Quarter.ToString()
                    });
                AreaRegistration.RegisterAllAreas();
            }
        }

        public void Preload(string[] parameters)
        {
        }

        public void Uninitialize(InitializationEngine context)
        {
        }
    }
}