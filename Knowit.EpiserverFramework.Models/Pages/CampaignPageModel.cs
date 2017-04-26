using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Shell.ObjectEditing;
using EPiServer.Web;
using Knowit.EpiserverFramework.EpiCore.Features.ContentTypeThumbnail;
using Knowit.EpiserverFramework.EpiCore.Features.EnumEditorDescriptor;
using Knowit.EpiserverFramework.EpiCore.Features.PageTreeIcons;
using Knowit.EpiserverFramework.Models.Blocks;
using Knowit.EpiserverFramework.Models.Core;

namespace Knowit.EpiserverFramework.Models.Pages
{
    /// <summary>
    /// Campaign page model
    /// </summary>
    [ContentType(
        GUID = "b393dd53-d7c4-4532-913c-5de7432e3176",
        GroupName = ModelsConstants.ContentTypeGroupNames.PageType)]
    [ContentTypeThumbnail(ContentTypeThumbnailConstants.ContentTypeThumbnails.GeneralPage)]
    [PageTreeIcon(PageTreeIconsConstants.ContentTypeTreeIcons.GeneralPage)]
    public class CampaignPageModel : SitePageData
    {
        public enum SectionChoice
        {
            SeGora = 0,
            Evenemang = 1,
            Ata = 2,
            Bo = 3
        }

        //// Content tab

    [BackingType(typeof(PropertyNumber))]
    [EditorDescriptor(EditorDescriptorType = typeof(EnumEditorDescriptor<SectionChoice>))]
        public virtual SectionChoice SiteSection { get; set; }

        [Display(
        GroupName = SystemTabNames.Content,
           Order = 20)]
        [UIHint(UIHint.Image)]
        public virtual ContentReference Thumbnail { get; set; }

        [Display(
          GroupName = SystemTabNames.Content,
         Order = 30)]
        [AllowedTypes(typeof(ImageData))]
        public virtual ContentArea ImageSlidesArea { get; set; }

        [Display(
           GroupName = SystemTabNames.Content,
          Order = 40)]
        public virtual ContentArea RightColumn { get; set; }

        [Display(
           GroupName = SystemTabNames.Content,
            Order = 60)]
        [CultureSpecific]
        public virtual XhtmlString Extract { get; set; }

        [Display(
            GroupName = SystemTabNames.Content,
            Order = 70)]
        [CultureSpecific]
        public virtual XhtmlString MainBody { get; set; }

        [Display(
           GroupName = SystemTabNames.Content,
           Order = 80)]
        public virtual ContentArea MainColumn { get; set; }

        [Display(
          GroupName = SystemTabNames.Content,
          Order = 99)]
        public virtual bool Menu { get; set; }
    }
}