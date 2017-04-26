using EPiServer.DataAnnotations;
using Knowit.EpiserverFramework.EpiCore.Features.ContentTypeThumbnail;
using Knowit.EpiserverFramework.EpiCore.Features.PageTreeIcons;
using Knowit.EpiserverFramework.Models.Core;

namespace Knowit.EpiserverFramework.Models.Pages
{
    /// <summary>
    /// Container page model
    /// </summary>
    [ContentType(
        GUID = "757c0bad-8dad-4cd1-9526-ed2e2496e7f0",
        GroupName = ModelsConstants.ContentTypeGroupNames.Special)]
    [ContentTypeThumbnail(ContentTypeThumbnailConstants.ContentTypeThumbnails.ContainerPage)]
    [PageTreeIcon(PageTreeIconsConstants.ContentTypeTreeIcons.ContainerPage)]

    public class ContainerPageModel : SitePageData
    {
        //// Content tab
    }
}