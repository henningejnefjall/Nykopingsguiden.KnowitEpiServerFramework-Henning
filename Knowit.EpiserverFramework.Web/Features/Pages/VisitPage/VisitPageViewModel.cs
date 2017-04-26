using System.Collections.Generic;
using EPiServer.Core;
using Knowit.EpiserverFramework.Models.Pages;
using Knowit.EpiserverFramework.Models.ViewModels;

namespace Knowit.EpiserverFramework.Web.Features.Pages.VisitPage
{
    /// <summary>
    /// Visit page view model
    /// </summary>
    public class VisitPageViewModel : PageViewModel<VisitPageModel>
    {
        public VisitPageViewModel(VisitPageModel currentPage) : base(currentPage)
        {
        }

        public IEnumerable<PageData> CategoryPages { get; set; }
    }
}