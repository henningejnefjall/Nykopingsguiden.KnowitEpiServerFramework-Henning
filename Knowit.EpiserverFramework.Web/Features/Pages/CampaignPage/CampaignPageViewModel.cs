using Knowit.EpiserverFramework.Models.Pages;
using Knowit.EpiserverFramework.Models.ViewModels;

namespace Knowit.EpiserverFramework.Web.Features.Pages.CampaignPage
{
    /// <summary>
    /// Campaign page view model
    /// </summary>
    public class CampaignPageViewModel : PageViewModel<CampaignPageModel>
    {
        public CampaignPageViewModel(CampaignPageModel currentPage) : base(currentPage)
        {
        }
    }
}