using System;
using System.Collections.Generic;
using System.Linq;
using EPiServer;
using EPiServer.Core;
using EPiServer.ServiceLocation;
using EPiServer.Web;
using EPiServer.Web.Routing;
using Knowit.EpiserverFramework.Models.Pages;

namespace Knowit.EpiserverFramework.Utilities.EpiserverUtilities
{
    public static class Heextensions
    {
        public static string CheckActive(PageData page)
        {
            var pageRouteHelper = EPiServer.ServiceLocation.ServiceLocator.Current.GetInstance<IPageRouteHelper>();

            PageReference currentPageLink = pageRouteHelper.PageLink;
            PageData currentPage = currentPageLink.GetPage();

            if (page.ContentLink == currentPage.ContentLink)
            {
                return "class=active";
            }

            return string.Empty;
        }

        public static ContentReference GetCategoryImage(this Guid guid)
        {
            var catImg = new ContentReference();

            if (guid != Guid.Empty)
            {
                var contentReference = PermanentLinkUtility.FindContentReference(guid);
                var repository = ServiceLocator.Current.GetInstance<IContentRepository>();
                var page = repository.Get<PageData>(contentReference);
                IEnumerable<CategoryImagePageModel> categoryImages = new List<CategoryImagePageModel>();
                if (page.Category != null)
                {
                    categoryImages =
                        repository.GetDescendents(PageReference.StartPage)
                            .Where(p => repository.Get<IContent>(p) is CategoryImagePageModel)
                            .Select(repository.Get<CategoryImagePageModel>)
                            .Where(x =>
                                x.Category != null &&
                                x.Category.Intersect(page.Category as CategoryList).Any());
                }
                else
                {
                    categoryImages =
                         repository.GetDescendents(PageReference.StartPage)
                             .Where(p => repository.Get<IContent>(p) is CategoryImagePageModel)
                             .Select(repository.Get<CategoryImagePageModel>)
                             .Where(x =>
                                 x.Category != null &&
                                 x.Category.Intersect(page.Category).Any());
                }

                foreach (CategoryImagePageModel categoryImage in categoryImages)
                {
                    catImg = categoryImage.Thumbnail;
                }
            }

            return catImg;
        }

        public static string CheckPageType(PageData page)
        {
            // var pageType = contentTypeRepository.Load<PageData>(); //grr commit
            // pageType = contentTypeRepository.Load<CompanyPage>();
            string typ = "none";

            switch (page.PageTypeName.ToString())
            {
                case "CompanyPage":
                {
                    typ = "ata";
                    break;
                }

                case "EventPage":
                {
                    typ = "event";
                    break;
                }

                case "VisitPageModel":
                {
                    typ = "segora";
                    break;
                }

                default:
                {
                    typ = "default";
                    break;
                }
            }

            return typ;
        }
    }
}