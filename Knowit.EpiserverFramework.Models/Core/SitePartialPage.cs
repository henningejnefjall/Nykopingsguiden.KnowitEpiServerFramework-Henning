using EPiServer.Web;

namespace Knowit.EpiserverFramework.Models.Core
{
    /// <summary>
    /// Base class for all partial views
    /// </summary>
    /// <typeparam name="T">Any page type inheriting from SitePageData</typeparam>
    public abstract class SitePartialPageTemplate<T> : ContentControlBase<SitePageData, T> where T : SitePageData
    {
    }
}
