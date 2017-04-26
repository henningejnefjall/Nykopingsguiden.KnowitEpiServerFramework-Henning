using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Web;
using Knowit.EpiserverFramework.EpiCore.Features.ContentTypeThumbnail;
using Knowit.EpiserverFramework.EpiCore.Features.PageTreeIcons;
using Knowit.EpiserverFramework.Models.Blocks;
using Knowit.EpiserverFramework.Models.Core;

namespace Knowit.EpiserverFramework.Models.Pages
{
    /// <summary>
    /// Sub page list page model
    /// </summary>
    [ContentType(
        GUID = "b393ed53-d7c4-4212-913c-5de7052e3076",
        GroupName = ModelsConstants.ContentTypeGroupNames.PageType)]
    [ContentTypeThumbnail(ContentTypeThumbnailConstants.ContentTypeThumbnails.SubPageListPage)]
    [PageTreeIcon(PageTreeIconsConstants.ContentTypeTreeIcons.SubPageListPage)]
    public class SubPageListPageModel : SitePageData
    {
        //// Content tab
        
        [Display(
        GroupName = SystemTabNames.Content,
           Order = 20)]
        [UIHint(UIHint.Image)]
        public virtual ContentReference Thumbnail { get; set; }

        [Display(
           GroupName = SystemTabNames.Content,
            Order = 40)]
        [CultureSpecific]
        [UIHint(UIHint.Textarea)]
        public virtual string Description { get; set; }

        [Display(
            GroupName = SystemTabNames.Content,
           Order = 50)]
        [AllowedTypes(typeof(ImageData))]
        public virtual ContentArea ImageSlidesArea { get; set; }

        [Display(
            GroupName = SystemTabNames.Content,
           Order = 60)]
        public virtual ContentArea RightColumn { get; set; }

        [Display(
           GroupName = SystemTabNames.Content,
           Order = 70)]
        public virtual ContentArea MainColumnTop { get; set; }

        [Display(
           GroupName = SystemTabNames.Content,
           Order = 80)]
        public virtual ContentArea MainColumnBottom { get; set; }
    }
}