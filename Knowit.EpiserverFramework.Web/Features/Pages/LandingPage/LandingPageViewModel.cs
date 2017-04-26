using Knowit.EpiserverFramework.Models.Pages;
using Knowit.EpiserverFramework.Models.ViewModels;

namespace Knowit.EpiserverFramework.Web.Features.Pages.LandingPage
{
    /// <summary>
    /// Landing page view model
    /// </summary>
    public class LandingPageViewModel : PageViewModel<LandingPageModel>
    {
        public LandingPageViewModel(LandingPageModel currentPage) : base(currentPage)
        {
        }
    }
}