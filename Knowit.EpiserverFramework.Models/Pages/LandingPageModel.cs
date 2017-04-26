using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Web;
using Knowit.EpiserverFramework.EpiCore.Features.ContentTypeThumbnail;
using Knowit.EpiserverFramework.EpiCore.Features.PageTreeIcons;
using Knowit.EpiserverFramework.Models.Core;

namespace Knowit.EpiserverFramework.Models.Pages
{
    /// <summary>
    /// Landing page model
    /// </summary>
    [ContentType(
        GUID = "95ca24f1-b2ed-4d72-abc2-d090ee23445f",
        GroupName = ModelsConstants.ContentTypeGroupNames.PageType)]
    [ContentTypeThumbnail(ContentTypeThumbnailConstants.ContentTypeThumbnails.LandingPage)]
    [PageTreeIcon(PageTreeIconsConstants.ContentTypeTreeIcons.LandingPage)]
    public class LandingPageModel : SitePageData
    {
        //// Content tab

        [Display(
            GroupName = SystemTabNames.Content,
            Order = 10)]
        [UIHint(UIHint.Textarea)]
        public virtual string MainIntro { get; set; }

        [Display(
            GroupName = SystemTabNames.Content,
            Order = 20)]
        [UIHint(UIHint.Image)]
        public virtual ContentReference Image { get; set; }

        [Display(
            GroupName = SystemTabNames.Content,
            Order = 30)]
        [UIHint(UIHint.Image)]
        public virtual ContentReference MobileImage { get; set; }

        [Display(
            GroupName = SystemTabNames.Content,
            Order = 40)]
        [UIHint(UIHint.Textarea)]
        public virtual string Movie { get; set; }

        [Display(
            GroupName = SystemTabNames.Content,
            Order = 50)]
        public virtual ContentArea ContentArea { get; set; }
    }
}