using System.ComponentModel.DataAnnotations;
using EPiServer;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.ServiceLocation;
using Knowit.EpiserverFramework.EpiCore.Features.CategoryHandler;
using Knowit.EpiserverFramework.Models.LocalBlocks;
using Knowit.EpiserverFramework.Models.Pages;
using Knowit.EpiserverFramework.Models.Pages.MeetInNykgPages;

namespace Knowit.EpiserverFramework.Models.Core
{
    /// <summary>
    /// Base class for page types
    /// </summary>
    public abstract class SitePageData : PageData
    {
        //// Overrides

        [HideCategory]
        public override CategoryList Category { get; set; }

        //// Haeder tab

        [Display(
            GroupName = SystemTabNames.PageHeader,
            Order = 10)]
        [CultureSpecific]
        public virtual string Heading
        {
            get
            {
                var heading = this.GetPropertyValue(page => page.Heading);

                // Use explicitly set Heading, otherwise fall back to page name
                return !string.IsNullOrWhiteSpace(heading) ? heading : PageName;
            }

            set
            {
                this.SetPropertyValue(page => page.Heading, value);
            }
        }

        //// SEO tab

        [Display(
            GroupName = SiteGroupDefinitions.Seo)]
        public virtual SearchEngineOptimizationBlockModel Seo { get; set; }

        //// Recursive properties

        /// <summary>
        /// Gets settings page
        /// </summary>
        [Editable(false)]
        public virtual SettingsPageModel Settings
        {
            get
            {
                if (ContentLink.ID == 0)
                {
                    return null;
                }

                var currentPage = ServiceLocator.Current.GetInstance<IContentLoader>().Get<IContent>(ContentLink);

                if (currentPage is SettingsPageModel)
                {
                    return null;
                }

                if (currentPage is StartPageModel && (currentPage as StartPageModel).SettingsPage != null)
                {
                    return ServiceLocator.Current.GetInstance<IContentLoader>().Get<PageData>((currentPage as StartPageModel).SettingsPage) as SettingsPageModel;
                }

                if (currentPage is MeetInNykgStartPageModel)
                {
                    var startPage = ServiceLocator.Current.GetInstance<IContentLoader>().Get<StartPageModel>(ContentReference.StartPage);
                    if (startPage.SettingsPage != null)
                    {
                        return ServiceLocator.Current.GetInstance<IContentLoader>().Get<PageData>(startPage.SettingsPage) as SettingsPageModel;
                    }
                }

                var ancestors = ServiceLocator.Current.GetInstance<IContentLoader>().GetAncestors(ContentLink);

                foreach (var ancestor in ancestors)
                {
                    if ((ancestor is StartPageModel) && (ancestor as StartPageModel).SettingsPage != null)
                    {
                        return ServiceLocator.Current.GetInstance<IContentLoader>().Get<PageData>((ancestor as StartPageModel).SettingsPage) as SettingsPageModel;
                    }

                    if (ancestor is MeetInNykgStartPageModel)
                    {
                        var startPage = ServiceLocator.Current.GetInstance<IContentLoader>().Get<StartPageModel>(ContentReference.StartPage);
                        if (startPage.SettingsPage != null)
                        {
                            return ServiceLocator.Current.GetInstance<IContentLoader>().Get<PageData>(startPage.SettingsPage) as SettingsPageModel;
                        }
                    }
                }

                return null;
            }
        }
    }
}
