using System.Web.Mvc;
using EPiServer.Web.Mvc;
using Knowit.EpiserverFramework.Models.Pages;

namespace Knowit.EpiserverFramework.Web.Features.Pages.ContainerPage
{
    /// <summary>
    /// Container page controller
    /// </summary>
    public class ContainerPageController : PageController<ContainerPageModel>
    {
        public ActionResult Index(ContainerPageModel currentPage)
        {
            var model = new ContainerPageViewModel(currentPage);

            return View(model);
        }
    }
}