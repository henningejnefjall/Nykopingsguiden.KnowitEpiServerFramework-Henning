using System.Web.Mvc;
using EPiServer.Web.Mvc;
using EPiServer.Web.WebControls;
using Knowit.EpiserverFramework.Models.Pages.MeetInNykgPages;

namespace Knowit.EpiserverFramework.Web.Features.Pages.MeetInNykgPages.MeetInNykgStartPage
{
    /// <summary>
    /// Meet in Nykoping start page controller
    /// </summary>
    public class MeetInNykgStartPageController : PageController<MeetInNykgStartPageModel>
    {
        public ActionResult Index(MeetInNykgStartPageModel currentPage)
        {
            ViewData.Add(RenderSettings.HasContainerElement, false);

            var model = new MeetInNykgStartPageViewModel(currentPage);

            return View(model);
        }
    }
}