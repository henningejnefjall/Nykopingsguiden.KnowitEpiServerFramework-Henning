using Knowit.EpiserverFramework.Models.Pages;
using Knowit.EpiserverFramework.Models.ViewModels;

namespace Knowit.EpiserverFramework.Web.Features.Pages.EventCreatePage
{
    /// <summary>
    /// Event create page view model
    /// </summary>
    public class EventCreatePageViewModel : PageViewModel<EventCreatePageModel>
    {
        public EventCreatePageViewModel(EventCreatePageModel currentPage) : base(currentPage)
        {
        }
    }
}