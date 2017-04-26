using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.ServiceLocation;
using EPiServer.Web.Routing;
using Knowit.EpiserverFramework.Utilities.EpiserverUtilities;

namespace Knowit.EpiserverFramework.Web.Helpers
{
    using Models.Core;

    public static class HtmlHelpers
    {
        public static List<MenuItem> MegaMenu(this HtmlHelper helper, ContentReference rootNode, bool requireVisibleInMenu = true, bool requirePageTemplate = true)
        {
            var currentContentLink = helper.ViewContext.RequestContext.GetContentLink();

            var contentLoader = ServiceLocator.Current.GetInstance<IContentLoader>();

            var pagePath = contentLoader.GetAncestors(currentContentLink)
                .Reverse()
                .Select(x => x.ContentLink)
                .SkipWhile(x => !x.CompareToIgnoreWorkID(rootNode))
                .ToList();

            var mainMenuItems = contentLoader.GetChildren<SitePageData>(rootNode)
                .FilterForDisplay(requirePageTemplate, requireVisibleInMenu)
                .Select(x => CreateMenuItem(x, currentContentLink, pagePath, contentLoader))
                .ToList();

            return mainMenuItems;
        }

        private static MenuItem CreateMenuItem(SitePageData page, ContentReference currentContentLink, List<ContentReference> pagePath, IContentLoader contentLoader)
        {
            var menuItem = new MenuItem(page)
            {
                Selected = page.ContentLink.CompareToIgnoreWorkID(currentContentLink) || pagePath.Contains(page.ContentLink),
                
                SubMenuItems = contentLoader.GetChildren<SitePageData>(page.ContentLink)
                    .FilterForDisplay(true, true)
                    .Select(x => CreateMenuItem(x, page.ContentLink, pagePath, contentLoader))
                    .ToList()
            };

            return menuItem;
        }

        public class MenuItem
        {
            public MenuItem(SitePageData page)
            {
                Page = page;
            }

            public SitePageData Page { get; set; }

            public bool Selected { get; set; }

            public List<MenuItem> SubMenuItems { get; set; }
        }
    }
}