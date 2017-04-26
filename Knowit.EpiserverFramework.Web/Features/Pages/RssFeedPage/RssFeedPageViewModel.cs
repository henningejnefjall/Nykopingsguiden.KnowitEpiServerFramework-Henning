using Knowit.EpiserverFramework.Models.Pages;
using Knowit.EpiserverFramework.Models.ViewModels;

namespace Knowit.EpiserverFramework.Web.Features.Pages.RssFeedPage
{
    /// <summary>
    /// RSS feed page view model
    /// </summary>
    public class RssFeedPageViewModel : PageViewModel<RssFeedPageModel>
    {
        public RssFeedPageViewModel(RssFeedPageModel rssFeedPage) : base(rssFeedPage)
        {
        }
    }
}