using EPiServer.DataAnnotations;
using EPiServer.Framework.DataAnnotations;
using Knowit.EpiserverFramework.EpiCore.Features.ContentTypeThumbnail;
using Knowit.EpiserverFramework.EpiCore.Features.PageTreeIcons;
using Knowit.EpiserverFramework.Models.Core;

namespace Knowit.EpiserverFramework.Models.Media
{
    /// <summary>
    /// Power point file media model
    /// </summary>
    [ContentType(
        GUID = "5bd68976-e69f-4732-90d8-c9a984bda419")]
    [MediaDescriptor(ExtensionString = "ppt, pptx")]
    [ContentTypeThumbnail(PageTreeIconsConstants.Icons.FileEye2)]
    public class PowerPointMediaModel : SiteMediaData
    {
        //// Content tab
    }
}