using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EPiServer;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.Editor;
using EPiServer.ServiceLocation;
using EPiServer.Web;
using EPiServer.Web.Routing;
using Knowit.EpiserverFramework.Models.Pages;

namespace Knowit.EpiserverFramework.Utilities.EpiserverUtilities
{
    public static class ContentExtensions
    {
        /// <summary>
        /// Get external url
        /// </summary>
        /// <param name="content">IContent</param>
        /// <returns>External url</returns>
        public static string GetExternalUrl(this IContent content)
        {
            var internalUrl = UrlResolver.Current.GetUrl(content.ContentLink);

            var url = new UrlBuilder(internalUrl);

            Global.UrlRewriteProvider.ConvertToExternal(url, null, Encoding.UTF8);

            var friendlyUrl = UriSupport.AbsoluteUrlBySettings(url.ToString());

            return friendlyUrl;
        }

        /// <summary>
        /// Get category from link
        /// </summary>
        /// <param name="guid">GUID</param>
        /// <returns>string</returns>
        public static string GetCategoryFromLink(this Guid guid)
        {
            string retVal = string.Empty;
            if (guid != Guid.Empty)
            { 
            var contentReference = PermanentLinkUtility.FindContentReference(guid);
            var repository = ServiceLocator.Current.GetInstance<IContentRepository>();
            var page = repository.Get<PageData>(contentReference);

                var catList = new CategoryList();
                if (page != null)
                {
                    if (page.Category.Count != 0)
                    {
                        catList = page.Category;
                    }

                    if (catList.Count != 0)
                    {
                        var pageCat = catList.First();
                        var locator = ServiceLocator.Current.GetInstance<CategoryRepository>();
                        var rootCategory = locator.GetRoot();
                        var theCat = rootCategory.FindChild(pageCat);

                        int segora = int.Parse(System.Configuration.ConfigurationManager.AppSettings["CategorySeGora"]);
                        int ata = int.Parse(System.Configuration.ConfigurationManager.AppSettings["CategoryAta"]);
                        int bo = int.Parse(System.Configuration.ConfigurationManager.AppSettings["CategoryBo"]);

                        if (theCat.ID == segora || theCat.Parent.ID == segora || theCat.Parent.Parent.ID == segora)
                        {
                            retVal = "segora";
                        }

                        if (theCat.ID == ata || theCat.Parent.ID == ata || theCat.Parent.Parent.ID == ata)
                        {
                            retVal = "ata";
                        }

                        if (theCat.ID == bo || theCat.Parent.ID == bo || theCat.Parent.Parent.ID == bo)
                        {
                            retVal = "bo";
                        }
                    }
                }
            }

            return retVal;
        }

        /// <summary>
        /// Get image from link
        /// </summary>
        /// <param name="guid">GUID</param>
        /// <returns>ContentReference</returns>
        public static ContentReference GetImageFromLink(this Guid guid)
        {
            var catImg = new ContentReference();

            if (guid != Guid.Empty)
            {
                var contentReference = PermanentLinkUtility.FindContentReference(guid);
                var repository = ServiceLocator.Current.GetInstance<IContentRepository>();
                var page = repository.Get<PageData>(contentReference);
                IEnumerable<CategoryImagePageModel> categoryImages = new List<CategoryImagePageModel>();
            
                categoryImages =
                    repository.GetDescendents(PageReference.StartPage)
                        .Where(p => repository.Get<IContent>(p) is CategoryImagePageModel)
                        .Select(repository.Get<CategoryImagePageModel>)
                        .Where(x =>
                            x.Category != null &&
                            x.Category.Intersect(page.Category).Any());

                foreach (CategoryImagePageModel categoryImage in categoryImages)
                {
                    catImg = categoryImage.Thumbnail;
                }
            }

            return catImg;
        }

        public static T GetPropertyValueRecursive<T>(this ContentData contentData, string propertyName)
        {
            var val = contentData.GetPropertyValue(propertyName, default(T));

            if (val != null || PageEditing.PageIsInEditMode)
            { 
                return val;            // get parent content data
            }

            var contentLoader = ServiceLocator.Current.GetInstance<IContentLoader>();
            var parent = contentLoader.Get<ContentData>(((IContent)contentData).ParentLink);

            if (parent == null || ((IContent)parent).ContentLink == ContentReference.RootPage)
            {
                return default(T);
            }

                return GetPropertyValueRecursive<T>(parent, propertyName);
        }

        /// <summary>
        /// Get page reference recursive
        /// </summary>
        /// <typeparam name="T">type T</typeparam>
        /// <param name="pageData">PageData</param>
        /// <param name="propertyName">Proerty name</param>
        /// <returns>PageRefernce</returns>
        public static PageReference GetPagereferenceRecursive<T>(this PageData pageData, string propertyName)
        {
            if (pageData != null || PageEditing.PageIsInEditMode)
            {
                return pageData.PageLink;            // get parent content data
            }

            var parent = pageData.ParentLink;
            if (parent == null || parent == PageReference.RootPage)
            {
                return new PageReference();
            }

            return GetPagereferenceRecursive<T>(GetPage(parent), propertyName);
        }

        /// <summary>
        /// Get page
        /// </summary>
        /// <param name="pageLink">Pagereference</param>
        /// <returns>PageData</returns>
        public static PageData GetPage(this PageReference pageLink)
        {
            if (pageLink != null)
            {
                return DataFactory.Instance.GetPage(pageLink);
            }

            return new PageData();
        }
    }
}
