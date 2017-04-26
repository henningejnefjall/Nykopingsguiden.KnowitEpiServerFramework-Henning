using Knowit.EpiserverFramework.Models.Pages;
using Knowit.EpiserverFramework.Models.ViewModels;

namespace Knowit.EpiserverFramework.Web.Features.Pages.ChangePasswordPage
{
    /// <summary>
    /// Change password page view model
    /// </summary>
    public class ChangePasswordPageViewModel : PageViewModel<ChangePasswordPageModel>
    {
        public ChangePasswordPageViewModel(ChangePasswordPageModel currentPage) : base(currentPage)
        {
        }
    }
}