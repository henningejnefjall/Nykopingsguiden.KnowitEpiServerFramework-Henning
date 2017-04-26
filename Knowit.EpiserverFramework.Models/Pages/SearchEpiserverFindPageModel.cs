using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using Knowit.EpiserverFramework.EpiCore.Features.ContentTypeThumbnail;
using Knowit.EpiserverFramework.EpiCore.Features.PageTreeIcons;
using Knowit.EpiserverFramework.Models.Core;

namespace Knowit.EpiserverFramework.Models.Pages
{
    /// <summary>
    /// Search EPiServer find page model
    /// </summary>
    [ContentType(
        GUID = "a28444db-2b27-4489-bb07-53419652715d",
        GroupName = ModelsConstants.ContentTypeGroupNames.Special,
        AvailableInEditMode = true)]
    [AvailableContentTypes(Availability.None)]
    [ContentTypeThumbnail(ContentTypeThumbnailConstants.ContentTypeThumbnails.SearchPage)]
    [PageTreeIcon(PageTreeIconsConstants.ContentTypeTreeIcons.SearchPage)]
    public class SearchEpiserverFindPageModel : SitePageData
    {
        //// Content tab
        [Display(
          GroupName = SystemTabNames.Content,
          Order = 10)]
        public virtual ContentArea RightColumn { get; set; }

        [Display(
          GroupName = SystemTabNames.Content,
          Order = 20)]
        public virtual ContentArea ContentArea { get; set; }

        // Allow editors to control how many hits should be displayed
        // on each search result listing when doing paging.
        [Range(0, 100)]
        [DefaultValue(10)]
        [Required]
        [Display(
          GroupName = SystemTabNames.Settings,
          Order = 30)]
        public virtual int PageSize { get; set; }

        // Allow editors to control wether matching keywords in 
        // search hit titles should be highlighted.
        [Display(
          GroupName = SystemTabNames.Settings,
          Order = 40)]
        public virtual bool HighlightTitles { get; set; }

        // Allow editors to control wether matching keywords in 
        // excerpt texts for search hits should be highlighted.
        // If false the beginning of the search text will be retrieved.
        [Display(
          GroupName = SystemTabNames.Settings,
          Order = 40)]
        public virtual bool HighlightExcerpts { get; set; }

        // Allow editors to specify how long excerpt text to retrieve
        // and show for each search hit.
        [Range(0, 1000)]
        [DefaultValue(200)]
        [Required]
        [Display(
          GroupName = SystemTabNames.Settings,
          Order = 60)]
        public virtual int ExcerptLength { get; set; }

        [Display(
          GroupName = SystemTabNames.Settings,
          Order = 70)]
        public virtual bool UseAndForMultipleSearchTerms { get; set; }
    }
}