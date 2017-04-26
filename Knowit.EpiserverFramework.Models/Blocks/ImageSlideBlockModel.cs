using System.ComponentModel.DataAnnotations;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Web;
using Knowit.EpiserverFramework.EpiCore.Features.ContentTypeThumbnail;
using Knowit.EpiserverFramework.Models.Core;
using Knowit.EpiserverFramework.Models.LocalBlocks;

namespace Knowit.EpiserverFramework.Models.Blocks
{
    /// <summary>
    /// Image slide block model
    /// </summary>
    [ContentType(
        GUID = "49e46f28-e3b5-4c0d-8c78-d7f821c8c208",
        GroupName = ModelsConstants.ContentTypeGroupNames.Block)]
    [ContentTypeThumbnail(ContentTypeThumbnailConstants.ContentTypeThumbnails.ImageSlideLinkBlock)]
    public class ImageSlideBlockModel : SiteBlockData
    {
        //// Content tab

        [Display(
            GroupName = SystemTabNames.Content,
            Order = 20)]
        [CultureSpecific]
        [UIHint(UIHint.Textarea)]
        public virtual string MainIntro { get; set; }

        [Display(
            GroupName = SystemTabNames.Content,
            Order = 30)]
        public virtual LinkBlockModel Link { get; set; }

        [Display(
            GroupName = SystemTabNames.Content,
            Order = 80)]
        public virtual ImageBlockModel SlideImage { get; set; }
    }
}