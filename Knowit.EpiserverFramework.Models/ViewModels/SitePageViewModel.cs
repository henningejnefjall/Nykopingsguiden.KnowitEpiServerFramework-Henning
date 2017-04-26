using EPiServer.Core;
using Knowit.EpiserverFramework.Models.Core;

namespace Knowit.EpiserverFramework.Models.ViewModels
{
    /// <summary>
    /// Page view model
    /// </summary>
    public static class SitePageViewModel
    {
        /// <summary>
        /// Returns a PageViewModel of type <typeparam name="T"/>.
        /// </summary>
        /// <remarks>
        /// Convenience method for creating PageViewModels without having to specify the type as methods can use type inference while constructors cannot.
        /// </remarks>
        /// <typeparam name="T">Type T</typeparam>
        /// <param name="page">Page of type T</param>
        /// <returns>PageViewModel of type T</returns>
        public static PageViewModel<T> Create<T>(T page) where T : SitePageData
        {
            return new PageViewModel<T>(page);
        }
    }

    /// <summary>
    /// Page view model of type T
    /// </summary>
    /// <typeparam name="T">Type T</typeparam>
    public class PageViewModel<T> : IPageViewModel<T> where T : SitePageData
    {
        public PageViewModel(T currentPage)
        {
            CurrentPage = currentPage;
        }

        public T CurrentPage { get; }

        public LayoutModel Layout { get; set; }

        public IContent Section { get; set; }
    }
}