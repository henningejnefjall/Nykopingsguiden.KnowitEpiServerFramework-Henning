using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using Knowit.EpiserverFramework.EpiCore.Features.ContentTypeThumbnail;
using Knowit.EpiserverFramework.EpiCore.Features.PageTreeIcons;
using Knowit.EpiserverFramework.Models.Blocks;
using Knowit.EpiserverFramework.Models.Core;

namespace Knowit.EpiserverFramework.Models.Pages.MeetInNykgPages
{
    /// <summary>
    /// Mett in Nykoping start page model
    /// </summary>
    [ContentType(
        GUID = "F18D02A9-5430-4518-9A32-6C62D13C8640",
        GroupName = ModelsConstants.ContentTypeGroupNames.MeetInNykg)]
    [ContentTypeThumbnail(ContentTypeThumbnailConstants.ContentTypeThumbnails.StartPage)]
    [PageTreeIcon(PageTreeIconsConstants.ContentTypeTreeIcons.StartPage)]
    public class MeetInNykgStartPageModel : SitePageData
    {
        //// Content tab
        
        [Display(
            GroupName = SystemTabNames.Content)]
        [AllowedTypes(typeof(ImageSlideLinkBlockModel))]
        public virtual ContentArea ImageSlider { get; set; }

        [Display(
            GroupName = SystemTabNames.Content)]
        [AllowedTypes(typeof(MeetInNykgContactBlockModel))]
        public virtual ContentArea PageCarousel { get; set; }

        [Display(
            GroupName = SystemTabNames.Content)]
        [AllowedTypes(typeof(SitePageData))]
        public virtual ContentArea ActivitiesAndExperiences { get; set; }

        [Display(
            GroupName = SystemTabNames.Content)]
        [AllowedTypes(typeof(ThemePageModel))]
        public virtual ContentArea ThemePages { get; set; }
    }
}