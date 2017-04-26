using EPiServer.DataAnnotations;
using EPiServer.Framework.DataAnnotations;
using Knowit.EpiserverFramework.EpiCore.Features.ContentTypeThumbnail;
using Knowit.EpiserverFramework.EpiCore.Features.PageTreeIcons;
using Knowit.EpiserverFramework.Models.Core;

namespace Knowit.EpiserverFramework.Models.Media
{
    /// <summary>
    /// Word file media model
    /// </summary>
    [ContentType(
        GUID = "41d56d2d-20eb-4428-bd56-4683649d8283")]
    [MediaDescriptor(ExtensionString = "doc, docx")]
    [ContentTypeThumbnail(PageTreeIconsConstants.Icons.FileWord)]
    public class WordMediaModel : SiteMediaData
    {
        //// Content tab
    }
}