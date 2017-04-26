using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Shell.ObjectEditing;
using EPiServer.Web;
using Knowit.EpiserverFramework.EpiCore.Features.ContentTypeThumbnail;
using Knowit.EpiserverFramework.EpiCore.Features.EnumEditorDescriptor;
using Knowit.EpiserverFramework.EpiCore.Features.PageTreeIcons;
using Knowit.EpiserverFramework.Models.Core;

namespace Knowit.EpiserverFramework.Models.Pages
{
    /// <summary>
    /// Sub page category page model
    /// </summary>
    [ContentType(
        GUID = "b390ed53-d7c4-4812-913c-5d47052e3076",
        GroupName = ModelsConstants.ContentTypeGroupNames.PageType)]
    [ContentTypeThumbnail(ContentTypeThumbnailConstants.ContentTypeThumbnails.SubPageCategoryPage)]
    [PageTreeIcon(PageTreeIconsConstants.ContentTypeTreeIcons.SubPageCategoryPage)]
    public class SubPageCategoryPageModel : SitePageData
    {
        public enum PagetypeChoice
        {
            BesoksmalOchVerksamheter = 0,
            Verksamheter = 1,
            Evenemang = 2,
            Lokal = 3,
            Besoksmal = 4
        }

        //// Content tab

        [BackingType(typeof(PropertyNumber))]
        [EditorDescriptor(EditorDescriptorType = typeof(EnumEditorDescriptor<PagetypeChoice>))]
        public virtual PagetypeChoice ListPageType { get; set; }
 
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