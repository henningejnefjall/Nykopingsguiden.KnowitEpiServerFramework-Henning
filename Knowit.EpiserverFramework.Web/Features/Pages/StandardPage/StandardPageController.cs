using System.Web.Mvc;
using EPiServer.Web.Mvc;
using Knowit.EpiserverFramework.Models.Pages;

namespace Knowit.EpiserverFramework.Web.Features.Pages.StandardPage
{
    /// <summary>
    /// Standard page controller
    /// </summary>
    public class StandardPageController : PageController<StandardPageModel>
    {
        public ActionResult Index(Models.Pages.StandardPageModel currentPage)
        {
            var model = new StandardPageViewModel(currentPage);

            return View(model);
        }
    }
}