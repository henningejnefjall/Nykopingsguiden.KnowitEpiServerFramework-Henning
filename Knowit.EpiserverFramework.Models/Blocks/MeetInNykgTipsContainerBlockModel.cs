using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using Knowit.EpiserverFramework.EpiCore.Features.ContentTypeThumbnail;
using Knowit.EpiserverFramework.Models.Core;
using Knowit.EpiserverFramework.Models.LocalBlocks;

namespace Knowit.EpiserverFramework.Models.Blocks
{
    /// <summary>
    /// Meet in nykoping tips container block model
    /// </summary>
    [ContentType(
        GUID = "1a126781-6372-4308-930a-b592b44a1ea2",
        GroupName = ModelsConstants.ContentTypeGroupNames.Block)]
    [ContentTypeThumbnail(ContentTypeThumbnailConstants.ContentTypeThumbnails.GeneralBlock)]
    public class MeetInNykgTipsContainerBlockModel : SiteBlockData
    {
        //// Content tab

        [Display(
            GroupName = SystemTabNames.Content,
            Order = 10)]
        public virtual LinkBlockModel Link { get; set; }

        [Display(
             GroupName = SystemTabNames.Content,
            Order = 20)]
        [AllowedTypes(typeof(SitePageData))]
        public virtual ContentArea PageCarousel { get; set; }
    }
}