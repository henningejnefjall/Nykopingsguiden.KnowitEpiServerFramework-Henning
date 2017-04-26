using Knowit.EpiserverFramework.Models.Pages.MeetInNykgPages;
using Knowit.EpiserverFramework.Models.ViewModels;

namespace Knowit.EpiserverFramework.Web.Features.Pages.MeetInNykgPages.MeetInNykgFacilityPage
{
    using System.Collections.Generic;
    using EPiServer.Core;

    /// <summary>
    /// Meet in Nykoping facility page view model
    /// </summary>
    public class MeetInNykgFacilityPageViewModel : PageViewModel<MeetInNykgFacilityPageModel>
    {
        public MeetInNykgFacilityPageViewModel(MeetInNykgFacilityPageModel currentPage) : base(currentPage)
        {
        }

        public IEnumerable<PageData> EventPages { get; set; }
    }
}