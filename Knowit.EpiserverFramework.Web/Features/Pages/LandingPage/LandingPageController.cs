using System.Web.Mvc;
using EPiServer.Web.Mvc;
using Knowit.EpiserverFramework.Models.Pages;

namespace Knowit.EpiserverFramework.Web.Features.Pages.LandingPage
{
    /// <summary>
    /// Landing page controller
    /// </summary>
    public class LandingPageController : PageController<LandingPageModel>
    {
        public ActionResult Index(LandingPageModel currentPage)
        {
            var model = new LandingPageViewModel(currentPage);

            return View(model);
        }
    }
}