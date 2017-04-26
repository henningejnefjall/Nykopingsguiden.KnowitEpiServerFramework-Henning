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
    /// Category image model
    /// </summary>
    [ContentType(
        GUID = "f752db02-af6d-4abf-a5dd-1a3b88016e65",
        GroupName = ModelsConstants.ContentTypeGroupNames.PageType)]
    [ContentTypeThumbnail(ContentTypeThumbnailConstants.ContentTypeThumbnails.CategoryImage)]
    [PageTreeIcon(PageTreeIconsConstants.ContentTypeTreeIcons.CategoryImage)]
    public class CategoryImagePageModel : SitePageData
    {
        //// Content tab

        [Display(
            GroupName = SystemTabNames.Content,
            Order = 20)]
        [UIHint(UIHint.Image)]
        public virtual ContentReference Thumbnail { get; set; }
    }
}