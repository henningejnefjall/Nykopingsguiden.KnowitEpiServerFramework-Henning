using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.ServiceLocation;
using EPiServer.Web.Routing;
using Knowit.EpiserverFramework.Models.Core;

namespace Knowit.EpiserverFramework.Web.Helpers
{
    public static class LinkHelper
    {
        public static string RenderLinkTag(this HtmlHelper helper, ContentReference contentReference, string title = null, string cssClass = null, string text = null)
        {
            var currentContent = !ContentReference.IsNullOrEmpty(contentReference) ? ServiceLocator.Current.GetInstance<IContentLoader>().Get<SitePageData>(contentReference) : null;

            if (currentContent == null)
            {
                return string.Empty;
            }

            var internalUrl = UrlResolver.Current.GetUrl(contentReference);

            var url = new UrlBuilder(internalUrl);

            Global.UrlRewriteProvider.ConvertToExternal(url, null, System.Text.Encoding.UTF8);

            var friendlyUrl = UriSupport.AbsoluteUrlBySettings(url.ToString());

            title = title != null ? $" title='{title}'" : string.Empty;

            cssClass = cssClass != null ? $" class='{cssClass}'" : string.Empty;

            return $"<a href='{friendlyUrl}'{title}{cssClass}>{text}</a>";
        }
    }
}