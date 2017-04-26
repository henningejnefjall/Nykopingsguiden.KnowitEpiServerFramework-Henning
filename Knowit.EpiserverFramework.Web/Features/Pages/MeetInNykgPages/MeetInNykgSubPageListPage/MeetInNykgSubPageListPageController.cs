using System.Web.Mvc;
using EPiServer.Web.Mvc;
using EPiServer.Web.WebControls;
using Knowit.EpiserverFramework.Models.Pages.MeetInNykgPages;

namespace Knowit.EpiserverFramework.Web.Features.Pages.MeetInNykgPages.MeetInNykgSubPageListPage
{
    /// <summary>
    /// Meet in Nykoping sub page list page controller
    /// </summary>
    public class MeetInNykgSubPageListPageController : PageController<MeetInNykgSubPageListPageModel>
    {
        public ActionResult Index(MeetInNykgSubPageListPageModel currentPage)
        {
            ViewData.Add(RenderSettings.HasContainerElement, false);

            var model = new MeetInNykgSubPageListPageViewModel(currentPage);

            return View(model);
        }
    }
}