using Knowit.EpiserverFramework.Models.Pages;
using Knowit.EpiserverFramework.Models.ViewModels;

namespace Knowit.EpiserverFramework.Web.Features.Pages.CompanyCreatePage
{
    /// <summary>
    /// Company create page view model
    /// </summary>
    public class CompanyCreatePageViewModel : PageViewModel<CompanyCreatePageModel>
    {
        public CompanyCreatePageViewModel(CompanyCreatePageModel currentPage) : base(currentPage)
        {
        }
    }
}