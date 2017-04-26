using System.Web.Mvc;
using EPiServer.Web.Mvc;
using EPiServer.Web.WebControls;
using Knowit.EpiserverFramework.Models.Pages;

namespace Knowit.EpiserverFramework.Web.Features.Pages.SubPageListPage
{
    /// <summary>
    /// Sub Page list page controller
    /// </summary>
    public class SubPageListPageController : PageController<SubPageListPageModel>
    {
        public ActionResult Index(SubPageListPageModel currentPage)
        {
            ViewData.Add(RenderSettings.HasContainerElement, false);

            var model = new SubPageListPageViewModel(currentPage);

            return View(model);
        }
    }
}