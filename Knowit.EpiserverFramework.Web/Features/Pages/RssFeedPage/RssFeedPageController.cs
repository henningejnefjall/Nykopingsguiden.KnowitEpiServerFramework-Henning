using System.ServiceModel.Syndication;
using System.Web.Mvc;
using System.Xml;
using System.Xml.Linq;
using EPiServer.Web.Mvc;
using Knowit.EpiserverFramework.Models.Pages;
using Knowit.EpiserverFramework.Utilities.EpiserverUtilities;

namespace Knowit.EpiserverFramework.Web.Features.Pages.RssFeedPage
{
    /// <summary>
    /// RSS feed page controller
    /// </summary>
    public class RssFeedPageController : PageController<RssFeedPageModel>
    {
        public ActionResult Index(Models.Pages.RssFeedPageModel currentPage)
        {
            //// TODO: Create RssFeedPageUtilities
            //// var feed = RssFeedPageUtilities.CreateSyndicationFeed(model);

            return new RssFeedPageActionResult { /* Feed = feed,*/ RssPage = currentPage };
        }
    }

    /// <summary>
    /// Rss feed page action result
    /// </summary>
    public class RssFeedPageActionResult : ActionResult
    {
        public SyndicationFeed Feed { get; set; }

        public RssFeedPageModel RssPage { get; set; }

        public override void ExecuteResult(ControllerContext context)
        {
            context.HttpContext.Response.ContentType = "application/rss+xml";

            XNamespace atom = "http://www.w3.org/2005/Atom";

            Feed.AttributeExtensions.Add(new XmlQualifiedName("atom", XNamespace.Xmlns.NamespaceName), atom.NamespaceName);

            Feed.ElementExtensions.Add(new XElement(atom + "link", new XAttribute("href", RssPage.GetFriendlyUrl()), new XAttribute("rel", "self"), new XAttribute("type", "application/rss+xml")));

            var rssFormatter = new Rss20FeedFormatter(Feed)
            {
                SerializeExtensionsAsAtom = false
            };

            using (var xmlWriter = XmlWriter.Create(context.HttpContext.Response.Output))
            {
                rssFormatter.WriteTo(xmlWriter);
            }
        }
    }
}