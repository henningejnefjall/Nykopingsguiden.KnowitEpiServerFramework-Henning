using EPiServer.Core;
using Knowit.EpiserverFramework.Models.Core;

namespace Knowit.EpiserverFramework.Models.ViewModels
{
    /// <summary>
    /// Defines common characteristics for view models for pages, including properties used by layout files.
    /// </summary>
    /// <typeparam name="T">Parameter T</typeparam>
    /// <remarks>
    /// Views which should handle several page types (T) can use this interface as model type rather than the
    /// concrete PageViewModel class, utilizing the that this interface is covariant.
    /// </remarks>
    public interface IPageViewModel<out T> where T : SitePageData
    {
        T CurrentPage { get; }

        LayoutModel Layout { get; set; }

        IContent Section { get; set; }
    }
}