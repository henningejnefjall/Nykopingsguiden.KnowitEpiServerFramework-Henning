using System.Web.Mvc;
using EPiServer.Find;
using EPiServer.Find.Cms;
using EPiServer.Find.Framework;
using EPiServer.Find.Framework.Statistics;
using EPiServer.Find.UnifiedSearch;
using EPiServer.Web.Mvc;
using Knowit.EpiserverFramework.Business;
using Knowit.EpiserverFramework.Models.Pages.MeetInNykgPages;
using Knowit.EpiserverFramework.Utilities.EpiserverUtilities;

namespace Knowit.EpiserverFramework.Web.Features.Pages.MeetInNykgPages.MeetInNykgSearchEpiserverFindPage
{
    /// <summary>
    /// Search EPiServer Find controller
    /// </summary>
    public class MeetInNykgSearchEpiserverFindPageController : PageController<MeetInNykgSearchEpiserverFindPageModel>
    {
        public MeetInNykgSearchEpiserverFindPageController(IClient client)
        {
            FindServiceClient = client;
        }

        public IClient FindServiceClient { get; private set; }
       
        public ActionResult Index(MeetInNykgSearchEpiserverFindPageModel currentPage, string q = "", int page = 1)
        {
            int pageSize = currentPage.PageSize;

            var skipNumber = 0;

            if (page > 0)
            { 
                skipNumber = (page - 1) * pageSize;
            }

            var model = new MeetInNykgSearchEpiserverFindPageViewModel(currentPage);

            ITypeSearch<ISearchContent> query = SearchClient.Instance.UnifiedSearchFor(q).UsingSynonyms().ApplyBestBets<ISearchContent>().Skip(skipNumber).Take(pageSize);

            var hitSpec = new HitSpecification
            {
                HighlightTitle = currentPage.HighlightTitles,
                HighlightExcerpt = currentPage.HighlightExcerpts,
                ExcerptLength = currentPage.ExcerptLength,
                EncodeTitle = false,
                EncodeExcerpt = false
            };

            model.Results = query.Track().GetResult(hitSpec);

            model.SearchQuery = q;

            model.TotalHits = model.Results.TotalMatching;

            if (model.TotalHits > 0)
            {
                int numberOfPages = (model.TotalHits / pageSize) + 1;

                if (numberOfPages > 1)
                {
                    for (int i = 1; i < numberOfPages + 1; i++)
                    {
                        var pagerLink = new CustomLink();
                        pagerLink.LinkText = i.ToString();
                        if (page == i)
                        {
                            pagerLink.IsActivePage = true;
                        }

                        pagerLink.Route = this.Url.ContentRoute(currentPage.PageLink, new { q = q, page = i });
                        model.PagerLinks.Add(pagerLink);
                    }
                }
            }

            return View(model);
        }
    }
}