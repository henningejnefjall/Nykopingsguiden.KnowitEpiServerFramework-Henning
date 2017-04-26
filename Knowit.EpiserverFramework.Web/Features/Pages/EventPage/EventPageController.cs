using System.Web.Mvc;
using EPiServer.Web.Mvc;
using Knowit.EpiserverFramework.Models.Pages;

namespace Knowit.EpiserverFramework.Web.Features.Pages.EventPage
{
    /// <summary>
    /// Event page controller
    /// </summary>
    public class EventPageController : PageController<EventPageModel>
    {
        public ActionResult Index(Models.Pages.EventPageModel currentPage)
        {
            var model = new EventPageViewModel(currentPage);
                
            return View(model);
        }
    }
}