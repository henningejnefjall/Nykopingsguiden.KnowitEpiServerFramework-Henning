using Knowit.EpiserverFramework.Models.Pages;
using Knowit.EpiserverFramework.Models.ViewModels;

namespace Knowit.EpiserverFramework.Web.Features.Pages.SubPageListPage
{
    /// <summary>
    /// Sub page list page view model
    /// </summary>
    public class SubPageListPageViewModel : PageViewModel<SubPageListPageModel>
    {
        public SubPageListPageViewModel(SubPageListPageModel currentPage) : base(currentPage)
        {
        }
    }
}