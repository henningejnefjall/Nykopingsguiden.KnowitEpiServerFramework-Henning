using Knowit.EpiserverFramework.Models.Pages;
using Knowit.EpiserverFramework.Models.ViewModels;

namespace Knowit.EpiserverFramework.Web.Features.Pages.ThemePage
{
    /// <summary>
    /// Theme page view model
    /// </summary>
    public class ThemePageViewModel : PageViewModel<ThemePageModel>
    {
        public ThemePageViewModel(ThemePageModel currentPage) : base(currentPage)
        {
        }
    }
}