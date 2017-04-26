using System.ComponentModel.DataAnnotations;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web;
using Knowit.EpiserverFramework.EpiCore.Features.ContentTypeThumbnail;
using Knowit.EpiserverFramework.EpiCore.Features.PageTreeIcons;
using Knowit.EpiserverFramework.Models.Core;

namespace Knowit.EpiserverFramework.Models.Media
{
    /// <summary>
    /// PDF file media model
    /// </summary>
    [ContentType(
        GUID = "f10fc47d-aed3-4307-9b34-59cfb2d37710")]
    [MediaDescriptor(ExtensionString = "pdf")]
    [ContentTypeThumbnail(PageTreeIconsConstants.Icons.FilePdf)]
    public class PdfMediaModel : SiteMediaData
    {
        //// Content tab

        [CultureSpecific]
        [UIHint(UIHint.Textarea)]
        [Display(
           GroupName = SystemTabNames.Content,
           Order = 20)]
        public virtual string MainIntro { get; set; }
    }
}   