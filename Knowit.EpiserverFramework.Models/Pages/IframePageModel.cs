using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using Knowit.EpiserverFramework.EpiCore.Features.ContentTypeThumbnail;
using Knowit.EpiserverFramework.EpiCore.Features.PageTreeIcons;
using Knowit.EpiserverFramework.Models.Core;

namespace Knowit.EpiserverFramework.Models.Pages
{
    /// <summary>
    /// Iframe page model
    /// </summary>
    [ContentType(
        GUID = "93365cf2-aabb-4edb-b0bf-6e96898f6044",
        GroupName = ModelsConstants.ContentTypeGroupNames.Special)]
    [AvailableContentTypes(Availability.None)]
    [ContentTypeThumbnail(ContentTypeThumbnailConstants.ContentTypeThumbnails.IframePage)]
    [PageTreeIcon(PageTreeIconsConstants.ContentTypeTreeIcons.IframePage)]
    public class IframePageModel : SitePageData
    {
        //// Content tab
    }
}