using Knowit.EpiserverFramework.Models.Pages;
using Knowit.EpiserverFramework.Models.ViewModels;

namespace Knowit.EpiserverFramework.Web.Features.Pages.EventPage
{
    /// <summary>
    /// Event page view model
    /// </summary>
    public class EventPageViewModel : PageViewModel<EventPageModel>
    {
        public EventPageViewModel(EventPageModel currentPage) : base(currentPage)
        {
        }
    }
}