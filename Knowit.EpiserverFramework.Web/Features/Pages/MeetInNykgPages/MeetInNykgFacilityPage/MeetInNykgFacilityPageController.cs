using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.Filters;
using EPiServer.Web.Mvc;
using Knowit.EpiserverFramework.Models.Pages.MeetInNykgPages;
using Knowit.EpiserverFramework.Utilities.EpiserverUtilities;

namespace Knowit.EpiserverFramework.Web.Features.Pages.MeetInNykgPages.MeetInNykgFacilityPage
{
    /// <summary>
    /// Meet in Nykoping facility page controller
    /// </summary>
    public class MeetInNykgFacilityPageController : PageController<MeetInNykgFacilityPageModel>
    {
        public ActionResult Index(MeetInNykgFacilityPageModel currentPage)
        {
            var model = new MeetInNykgFacilityPageViewModel(currentPage);

            IEnumerable<PageData> filteredChildren = new List<PageData>();
            IList<PageReference> allChildren = DataFactory.Instance.GetDescendents(ContentReference.StartPage);
            PageDataCollection pdc = new PageDataCollection();
            foreach (var page in allChildren)
            {
                if (page.GetPage().PageTypeName == "EventPage")
                { 
                    PageData pd = DataFactory.Instance.GetPage(page);
                    if (pd["Place"] != null)
                    { 
                        pdc.Add(pd);
                    }
                }
            }

            if (pdc.Count != 0)
            {
                // Todo: Add datesort
                    new FilterPropertySort("PageName", FilterSortDirection.Ascending).Filter(pdc);
                    filteredChildren =
                        FilterForVisitor.Filter(pdc)
                            .Cast<Models.Pages.EventPageModel>().Where(
                                p =>
                                    p.IsVisibleOnSite() && p.VisibleInMenu &&
                                    p.Place == currentPage.PageLink && p["HideList"] == null).Take(3);
            }

            model.EventPages = filteredChildren;

            return View(model);
        }
    }
}