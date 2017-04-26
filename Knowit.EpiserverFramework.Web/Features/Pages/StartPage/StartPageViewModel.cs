using Knowit.EpiserverFramework.Models.Pages;
using Knowit.EpiserverFramework.Models.ViewModels;

namespace Knowit.EpiserverFramework.Web.Features.Pages.StartPage
{
    /// <summary>
    /// Start page view model
    /// </summary>
    public class StartPageViewModel : PageViewModel<StartPageModel>
    {
        public StartPageViewModel(StartPageModel currentPage) : base(currentPage)
        {
        }
    }
}