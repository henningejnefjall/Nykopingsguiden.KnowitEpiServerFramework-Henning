using System.Web.Mvc;
using EPiServer.Web.Mvc;
using EPiServer.Web.WebControls;
using Knowit.EpiserverFramework.Models.Pages;

namespace Knowit.EpiserverFramework.Web.Features.Pages.CategoryImagePage
{
    /// <summary>
    /// Category Image page controller
    /// </summary>
    public class CategoryImagePageController : PageController<CategoryImagePageModel>
    {
        public ActionResult Index(CategoryImagePageModel currentPage)
        {
            ViewData.Add(RenderSettings.HasContainerElement, false);

            var model = new CategoryImagePageViewModel(currentPage);

            return View(model);
        }
    }
}