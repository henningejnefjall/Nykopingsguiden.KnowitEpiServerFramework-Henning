using Knowit.EpiserverFramework.Models.Pages;
using Knowit.EpiserverFramework.Models.ViewModels;

namespace Knowit.EpiserverFramework.Web.Features.Pages.RegisterPage
{
    /// <summary>
    /// Register page view model
    /// </summary>
    public class RegisterPageViewModel : PageViewModel<RegisterPageModel>
    {
        public RegisterPageViewModel(RegisterPageModel currentPage) : base(currentPage)
        {
        }
    }
}