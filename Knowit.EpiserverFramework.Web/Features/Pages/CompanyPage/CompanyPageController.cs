using System.Web.Mvc;

namespace Knowit.EpiserverFramework.Web.Features.Pages.CompanyPage
{
    /// <summary>
    /// Company page controller
    /// </summary>
    public class CompanyPageController : PageBaseController<Models.Pages.CompanyPageModel>
    {
        public ActionResult Index(Models.Pages.CompanyPageModel currentPage)
        {
            var model = new CompanyPageViewModel(currentPage);
                
            return View(model);
        }
    }
}