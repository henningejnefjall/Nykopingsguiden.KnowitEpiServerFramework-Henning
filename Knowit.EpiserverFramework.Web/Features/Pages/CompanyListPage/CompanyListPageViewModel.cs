using Knowit.EpiserverFramework.Models.Pages;
using Knowit.EpiserverFramework.Models.ViewModels;

namespace Knowit.EpiserverFramework.Web.Features.Pages.CompanyListPage
{
    /// <summary>
    /// Company list page view model
    /// </summary>
    public class CompanyListPageViewModel : PageViewModel<CompanyListPageModel>
    {
        public CompanyListPageViewModel(CompanyListPageModel currentPage) : base(currentPage)
        {
        }
    }
}