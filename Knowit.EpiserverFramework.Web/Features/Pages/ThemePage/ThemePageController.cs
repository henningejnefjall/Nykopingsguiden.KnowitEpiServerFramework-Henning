using System.Web.Mvc;
using EPiServer.Web.Mvc;
using Knowit.EpiserverFramework.Models.Pages;

namespace Knowit.EpiserverFramework.Web.Features.Pages.ThemePage
{
    public class ThemePageController : PageController<ThemePageModel>
    {
        public ActionResult Index(ThemePageModel currentPage)
        {
            var model = new ThemePageViewModel(currentPage);

            return View(model);
        }
    }
}