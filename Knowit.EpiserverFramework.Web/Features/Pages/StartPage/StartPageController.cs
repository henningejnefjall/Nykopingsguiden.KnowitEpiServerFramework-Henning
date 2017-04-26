using System.Web.Mvc;
using EPiServer.Web.Mvc;
using Knowit.EpiserverFramework.Models.Pages;

namespace Knowit.EpiserverFramework.Web.Features.Pages.StartPage
{
    /// <summary>
    /// Start page controller
    /// </summary>
    public class StartPageController : PageController<StartPageModel>
    {
        public ActionResult Index(StartPageModel currentPage)
        {
            var model = new StartPageViewModel(currentPage);
            
            return View(model);
        }
    }
}