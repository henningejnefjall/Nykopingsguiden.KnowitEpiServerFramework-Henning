using System.Web.Mvc;
using EPiServer.Web.Mvc;
using Knowit.EpiserverFramework.Models.Pages;

namespace Knowit.EpiserverFramework.Web.Features.Pages.CampaignPage
{
    /// <summary>
    /// Campaign page controller
    /// </summary>
    public class CampaignPageController : PageController<CampaignPageModel>
        {
            public ActionResult Index(CampaignPageModel currentPage)
            {
            var model = new CampaignPageViewModel(currentPage);

            return View(model);
            }
        }
    }