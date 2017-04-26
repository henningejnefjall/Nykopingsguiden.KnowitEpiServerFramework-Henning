using System.Collections.Generic;
using EPiServer.Find.Cms;
using EPiServer.Find.UnifiedSearch;
using Knowit.EpiserverFramework.Business;
using Knowit.EpiserverFramework.Models.Core;
using Knowit.EpiserverFramework.Models.Pages;
using Knowit.EpiserverFramework.Models.ViewModels;

namespace Knowit.EpiserverFramework.Web.Features.Pages.SearchEpiserverFindPage
{
    /// <summary>
    /// Search EPiServer Find view model
    /// </summary>
    public class SearchEpiserverFindPageViewModel : PageViewModel<SearchEpiserverFindPageModel>
    {
        public SearchEpiserverFindPageViewModel(SearchEpiserverFindPageModel currentPage) : base(currentPage)
        {
            PagerLinks = new List<CustomLink>();
        }

        public IContentResult<SitePageData> ContentResult { get; set; }

        public UnifiedSearchResults Results { get; set; }

        public string SearchQuery { get; set; }

        public int TotalHits { get; set; }

        public List<CustomLink> PagerLinks { get; set; }
    }
}