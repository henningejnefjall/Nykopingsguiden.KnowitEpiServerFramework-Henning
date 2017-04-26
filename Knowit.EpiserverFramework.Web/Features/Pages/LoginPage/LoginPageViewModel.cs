using Knowit.EpiserverFramework.Models.Pages;
using Knowit.EpiserverFramework.Models.ViewModels;

namespace Knowit.EpiserverFramework.Web.Features.Pages.LoginPage
{
    /// <summary>
    /// Login page view model
    /// </summary>
    public class LoginPageViewModel : PageViewModel<LoginPageModel>
    {
        public LoginPageViewModel(LoginPageModel currentPage) : base(currentPage)
        {
        }
    }
}