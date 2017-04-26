using System.Web.Mvc;
using EPiServer.Web.Mvc;
using EPiServer.Web.WebControls;
using Knowit.EpiserverFramework.Models.Pages.MeetInNykgPages;

namespace Knowit.EpiserverFramework.Web.Features.Pages.MeetInNykgPages.MeetInNykgArticlePage
{
    /// <summary>
    /// Meet in Nykoping article page controller
    /// </summary>
    public class MeetInNykgArticlePageController : PageController<MeetInNykgArticlePageModel>
    {
        public ActionResult Index(MeetInNykgArticlePageModel currentPage)
        {
            ViewData.Add(RenderSettings.HasContainerElement, false);

            var model = new MeetInNykgArticlePageViewModel(currentPage);

            return View(model);
        }
    }
}