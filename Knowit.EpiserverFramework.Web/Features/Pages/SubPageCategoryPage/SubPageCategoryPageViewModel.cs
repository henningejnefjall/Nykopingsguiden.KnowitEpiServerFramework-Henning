using System.Collections.Generic;
using EPiServer.Core;
using Knowit.EpiserverFramework.Models.Pages;
using Knowit.EpiserverFramework.Models.ViewModels;

namespace Knowit.EpiserverFramework.Web.Features.Pages.SubPageCategoryPage
{
    /// <summary>
    /// Sub page category page view model
    /// </summary>
    public class SubPageCategoryPageViewModel : PageViewModel<SubPageCategoryPageModel>
    {
        public SubPageCategoryPageViewModel(SubPageCategoryPageModel currentPage) : base(currentPage)
        {
        }

        public IEnumerable<PageData> CategoryPages { get; set; }
    }
}