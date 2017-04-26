using System.Collections.Generic;
using EPiServer.Core;
using Knowit.EpiserverFramework.Models.Pages.MeetInNykgPages;
using Knowit.EpiserverFramework.Models.ViewModels;

namespace Knowit.EpiserverFramework.Web.Features.Pages.MeetInNykgPages.MeetInNykgSubPageCategoryPage
{
    /// <summary>
    /// Meet in Nykoping sub page category page view modwel
    /// </summary>
    public class MeetInNykgSubPageCategoryPageViewModel : PageViewModel<MeetInNykgSubPageCategoryPageModel>
    {
        public MeetInNykgSubPageCategoryPageViewModel(MeetInNykgSubPageCategoryPageModel currentPage) : base(currentPage)
        {
        }

        public IEnumerable<PageData> CategoryPages { get; set; }
    }
}