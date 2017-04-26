using System.ComponentModel.DataAnnotations;
using EPiServer;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using EPiServer.Web;
using Knowit.EpiserverFramework.EpiCore.Features.ContentTypeThumbnail;
using Knowit.EpiserverFramework.EpiCore.Features.PageTreeIcons;
using Knowit.EpiserverFramework.Models.Core;

namespace Knowit.EpiserverFramework.Models.Pages
{
    /// <summary>
    /// Rss feed page model
    /// </summary>
    [SiteContentType(
        GUID = "a3542fc1-430f-4c57-ac81-991fd496b4d2",
        GroupName = ModelsConstants.ContentTypeGroupNames.Special)]
    [ContentTypeThumbnail(ContentTypeThumbnailConstants.ContentTypeThumbnails.Rss)]
    [PageTreeIcon(PageTreeIconsConstants.ContentTypeTreeIcons.RssFeedPage)]

    public class RssFeedPageModel : SitePageData
    {
        //// Content tab

        [Display(
           GroupName = SystemTabNames.Content,
           Order = 10)]
        [Required]
        public virtual PageReference RssStartPage { get; set; }

        [Display(
            GroupName = SystemTabNames.Content,
            Order = 20)]
        [Required]
        [CultureSpecific]
        public virtual string Title { get; set; }

        [Display(
            GroupName = SystemTabNames.Content,
            Order = 30)]
        [Required]
        public virtual string Copyright { get; set; }

        [Display(
            GroupName = SystemTabNames.Content,
            Order = 40)]
        [Required]
        [CultureSpecific]
        public virtual string Generator { get; set; }

        [Display(
            GroupName = SystemTabNames.Content,
            Order = 50)]
        [Required]
        [CultureSpecific]
        [UIHint(UIHint.Textarea)]
        public virtual string MainIntro { get; set; }

        [BackingType(typeof(PropertyImageUrl))]
        [UIHint(UIHint.Image)]
        [Display(
            GroupName = SystemTabNames.Content,
            Order = 60)]
        public virtual Url RssIcon { get; set; }

        [Display(
            GroupName = SystemTabNames.Content,
            Order = 70)]
        public virtual int NumberOfItemsToFeed { get; set; }

        [Display(
            GroupName = SystemTabNames.Content,
            Order = 80)]
        public virtual bool CrawlAllPages { get; set; }
    }
}