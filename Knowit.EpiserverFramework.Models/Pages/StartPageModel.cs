using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using Knowit.EpiserverFramework.EpiCore.Features.ContentTypeThumbnail;
using Knowit.EpiserverFramework.EpiCore.Features.PageTreeIcons;
using Knowit.EpiserverFramework.Models.Blocks;
using Knowit.EpiserverFramework.Models.Core;

namespace Knowit.EpiserverFramework.Models.Pages
{
    /// <summary>
    /// Start page model
    /// </summary>
    [ContentType(
        GUID = "b093ed53-d7c4-4532-913c-5de7052e3076",
        GroupName = ModelsConstants.ContentTypeGroupNames.PageType)]
    [ContentTypeThumbnail(ContentTypeThumbnailConstants.ContentTypeThumbnails.StartPage)]
    [PageTreeIcon(PageTreeIconsConstants.ContentTypeTreeIcons.StartPage)]
    public class StartPageModel : SitePageData
    {
        //// Content tab
        
        [UIHint("DialogOnly")]
        [Display(
            GroupName = SystemTabNames.Content,
            Order = 10)]
        [AllowedTypes(typeof(ImageSlideLinkBlockModel))]
        public virtual ContentArea ImageSlider { get; set; }

        [Display(
            GroupName = SystemTabNames.Content,
            Order = 20)]
        public virtual ContentArea PageCarousel { get; set; }

        [Display(
            GroupName = SystemTabNames.Content,
            Order = 30)]
        public virtual ContentArea ImageLinks { get; set; }

        //// Settings tab

        [Display(
            GroupName = SystemTabNames.Settings,
            Order = 40)]
        public virtual ContentReference SettingsPage { get; set; }
    }
}