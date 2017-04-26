using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Web;
using Knowit.EpiserverFramework.EpiCore.Features.ContentTypeThumbnail;
using Knowit.EpiserverFramework.EpiCore.Features.PageTreeIcons;
using Knowit.EpiserverFramework.Models.Core;

namespace Knowit.EpiserverFramework.Models.Pages.MeetInNykgPages
{
    /// <summary>
    /// Meet in Nykoping subPage list page model
    /// </summary>
    [ContentType(
        GUID = "CEEA4DED-B567-4951-8221-920E52CB4389",
        GroupName = ModelsConstants.ContentTypeGroupNames.MeetInNykg)]
    [ContentTypeThumbnail(ContentTypeThumbnailConstants.ContentTypeThumbnails.SubPageListPage)]
    [PageTreeIcon(PageTreeIconsConstants.ContentTypeTreeIcons.SubPageListPage)]
    public class MeetInNykgSubPageListPageModel : SitePageData
    {
        //// Content tab
        
        [Display(
            GroupName = SystemTabNames.Content,
            Order = 20)]
        [UIHint(UIHint.Image)]
        public virtual ContentReference Thumbnail { get; set; }

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