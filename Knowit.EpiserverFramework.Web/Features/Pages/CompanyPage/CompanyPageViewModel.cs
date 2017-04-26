using Knowit.EpiserverFramework.Models.Pages;
using Knowit.EpiserverFramework.Models.ViewModels;

namespace Knowit.EpiserverFramework.Web.Features.Pages.CompanyPage
{
    /// <summary>
    /// Company page view model
    /// </summary>
    public class CompanyPageViewModel : PageViewModel<CompanyPageModel>
    {
        public CompanyPageViewModel(CompanyPageModel currentPage) : base(currentPage)
        {
        }
    }
}