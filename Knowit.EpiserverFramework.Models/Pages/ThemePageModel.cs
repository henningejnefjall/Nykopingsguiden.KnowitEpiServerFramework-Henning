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
    /// Theme page model
    /// </summary>
    [ContentType(
        GUID = "b3936d53-d7c4-4f32-913c-5de7552e3076",
        GroupName = ModelsConstants.ContentTypeGroupNames.PageType)]
    [ContentTypeThumbnail(ContentTypeThumbnailConstants.ContentTypeThumbnails.GeneralPage)]
    [PageTreeIcon(PageTreeIconsConstants.ContentTypeTreeIcons.GeneralPage)]
    public class ThemePageModel : SitePageData
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
        [CultureSpecific]
        public virtual string Title { get; set; }

        [Display(
            GroupName = SystemTabNames.Content,
            Order = 40)]
        [CultureSpecific]
        public virtual string Extract { get; set; }

        [Display(
            GroupName = SystemTabNames.Content,
            Order = 40)]
        [CultureSpecific]
        public virtual XhtmlString MainBody { get; set; }

        [Display(
           GroupName = SystemTabNames.Content,
           Order = 70)]
        public virtual ContentArea MainColumn { get; set; }
    }
}