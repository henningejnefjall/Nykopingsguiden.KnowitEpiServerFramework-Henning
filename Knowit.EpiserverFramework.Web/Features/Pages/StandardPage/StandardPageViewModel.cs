using Knowit.EpiserverFramework.Models.Pages;
using Knowit.EpiserverFramework.Models.ViewModels;

namespace Knowit.EpiserverFramework.Web.Features.Pages.StandardPage
{
    /// <summary>
    /// Standard page view model
    /// </summary>
    public class StandardPageViewModel : PageViewModel<StandardPageModel>
    {
        public StandardPageViewModel(StandardPageModel currentPage) : base(currentPage)
        {
        }
    }
}