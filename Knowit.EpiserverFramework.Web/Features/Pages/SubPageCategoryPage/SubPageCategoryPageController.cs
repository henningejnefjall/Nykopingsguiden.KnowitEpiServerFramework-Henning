using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.Filters;
using EPiServer.Web.Mvc;
using Knowit.EpiserverFramework.Models.Pages;

namespace Knowit.EpiserverFramework.Web.Features.Pages.SubPageCategoryPage
{
    /// <summary>
    /// Sub Page with category page controller
    /// </summary>
    public class SubPageCategoryPageController : PageController<SubPageCategoryPageModel>
    {
        public ActionResult Index(SubPageCategoryPageModel currentPage)
        {
            var model = new SubPageCategoryPageViewModel(currentPage);

            IEnumerable<PageData> filteredChildren = new List<PageData>();
            var pageTypeName = model.CurrentPage.ListPageType;
            var pageTypeList = string.Empty;
            switch (pageTypeName)
            {           
                case SubPageCategoryPageModel.PagetypeChoice.Verksamheter:
                    pageTypeList = "CompanyPage";
                    break;
                case SubPageCategoryPageModel.PagetypeChoice.Evenemang:
                    pageTypeList = "EventPage";
                    break;
                case SubPageCategoryPageModel.PagetypeChoice.Lokal:
                    pageTypeList = "PlacePage";
                    break;
                case SubPageCategoryPageModel.PagetypeChoice.Besoksmal:
                    pageTypeList = "VisitPage";
                    break;
                default:
                    pageTypeList = "VisitPageCompanyPage";
                    break;
            }

            IList<PageReference> allChildren = DataFactory.Instance.GetDescendents(PageReference.StartPage);
            PageDataCollection pdc = new PageDataCollection();
            foreach (var page in allChildren)
            {
                PageData pd = DataFactory.Instance.GetPage(page);
                pdc.Add(pd);
            }

            if (pdc.Count != 0)
            {
                if (pageTypeList == "VisitPageCompanyPage")
                {
                    new FilterPropertySort("PageName", FilterSortDirection.Ascending).Filter(pdc);
                    filteredChildren =
                        FilterForVisitor.Filter(pdc)
                            .Where(
                                p =>
                                    p.IsVisibleOnSite() && p.VisibleInMenu &&
                                    (p.PageTypeName == "VisitPage" || p.PageTypeName == "CompanyPage")
                                    && p.Category != null &&
                                    p.Category.Intersect(model.CurrentPage.Category).Any());
                }
                else if (pageTypeList == "EventPage")
                {
                    // Todo - Add sort order for date and flagged event 
                    new FilterPropertySort("Date", FilterSortDirection.Ascending).Filter(pdc);
                    filteredChildren =
                        FilterForVisitor.Filter(pdc)
                            .Where(p => p.IsVisibleOnSite() && p.VisibleInMenu && (p.PageTypeName == "EventPage")
                                        && p.Category != null &&
                                        p.Category.Intersect(model.CurrentPage.Category).Any());
                }
                else
                {
                    new FilterPropertySort("PageName", FilterSortDirection.Ascending).Filter(pdc);
                    filteredChildren =
                        FilterForVisitor.Filter(pdc)
                            .Where(p => p.IsVisibleOnSite() && p.VisibleInMenu && (p.PageTypeName == pageTypeList)
                                        && p.Category != null &&
                                        p.Category.Intersect(model.CurrentPage.Category).Any());
                }        
            }

            model.CategoryPages = filteredChildren;

            return View(model);
        }
    }
}