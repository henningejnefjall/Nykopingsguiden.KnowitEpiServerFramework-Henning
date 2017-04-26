using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.Filters;
using EPiServer.ServiceLocation;
using Knowit.EpiserverFramework.Models.Pages;
using Knowit.EpiserverFramework.Utilities.EpiserverUtilities;

namespace Knowit.EpiserverFramework.Web.Features.Pages.VisitPage
{
    /// <summary>
    /// Visit page controller
    /// </summary>
    public class VisitPageController : PageBaseController<VisitPageModel>
    {
        public ActionResult Index(VisitPageModel currentPage)
        {
            var model = new VisitPageViewModel(currentPage);

            var pages = GetPagesCriteria(currentPage);

            pages = FilterToShow(pages, currentPage);

            model.CategoryPages = pages;

            return View(model);
        }

        public IEnumerable<CompanyPageModel> GetPagesCriteria(PageData current)
        {
            var contentTypeRepository = ServiceLocator.Current.GetInstance<IContentTypeRepository>();
            var pageType = contentTypeRepository.Load<CompanyPageModel>();

            var categories = current.Category;

            var pageRepository = ServiceLocator.Current.GetInstance<IPageCriteriaQueryService>();

            var contentRepository = ServiceLocator.Current.GetInstance<IContentRepository>();
            var startPage = contentRepository.Get<StartPageModel>(ContentReference.StartPage);
            SettingsPageModel settingsPage = contentRepository.Get<SettingsPageModel>(startPage.SettingsPage);
            PageReference parent = settingsPage.CompanyContainerPage;

            var criterias = new PropertyCriteriaCollection
            {
                new PropertyCriteria
                {
                    Condition = CompareCondition.Equal,
                    Value = pageType.ID.ToString(), // contentTypeRepository.Load<CompanyPage>().ID.ToString(),
                    Type = PropertyDataType.PageType,
                    Name = "PageTypeID",
                    Required = true
                }
            };

            foreach (var category in current.Category)
            {
                criterias.Add(new PropertyCriteria
                {
                    Condition = CompareCondition.Equal,
                    Value = category.ToString(),
                    Type = PropertyDataType.Category,
                    Name = "PageCategory"
                });
            }

            var pages = pageRepository.FindPagesWithCriteria(PageReference.StartPage, criterias).Cast<CompanyPageModel>();

            pages = pages.Where(x => ((x as IVersionable).Status.Equals(VersionStatus.Published) && !x.IsDeleted) && x.Property["SuperInactive"].Value as bool? != true && x.Property["Inactive"].Value as bool? != true);

            return pages;
        }
       
        public IEnumerable<PageData> GetPagesOther(PageData current)
        {
            // get usages, this also includes versions
            var contentTypeRepository = ServiceLocator.Current.GetInstance<IContentTypeRepository>();
            var pageType = contentTypeRepository.Load<CompanyPageModel>();
            var contentModelUsage = ServiceLocator.Current.GetInstance<IContentModelUsage>();
            var usages = contentModelUsage.ListContentOfContentType(pageType);
            var repository = ServiceLocator.Current.GetInstance<IContentRepository>();

            var categories = current.Category;

                var categoryPages = usages.Select(u => repository.Get<IContent>(u.ContentLink))
                    .Where(x =>

                        // ...filter published
                        (x as IVersionable).Status.Equals(VersionStatus.Published)

                        // remove deleted
                        && !x.IsDeleted)

                    // Cast to pagedata and check if they've got correct categories 
                    .Cast<PageData>().Where(x =>
                    x.Category != null && x.Category.Intersect(categories).Any() && x.Property["SuperInactive"].Value as bool? != true && x.Property["Inactive"].Value as bool? != true);

            // model.CategoryPages = categoryPages.Shuffle().Take(currentBlock.MaxItems);
            return categoryPages;
        }

        public IEnumerable<CompanyPageModel> FilterToShow(IEnumerable<CompanyPageModel> pages, PageData current)
        {
            int numberofitems = 3; //// kolla på sen

            //// pages = pages.Shuffle().Take(numberofitems);

            PageDataCollection flagged = new PageDataCollection();

            foreach (CompanyPageModel page in pages)
            {
                if (page.Flag == true)
                {
                    flagged.Add(page);                  
                }
            }

            pages = pages.Shuffle().Take(numberofitems);
            pages = flagged.Cast<CompanyPageModel>().Union(pages.Cast<CompanyPageModel>());

            return pages;
        }
    }
}