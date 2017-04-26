using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using Knowit.EpiserverFramework.EpiCore.Features.ContentTypeThumbnail;
using Knowit.EpiserverFramework.EpiCore.Features.PageTreeIcons;
using Knowit.EpiserverFramework.Models.Core;

namespace Knowit.EpiserverFramework.Models.Pages.MeetInNykgPages
{
    /// <summary>
    /// Meet in Nykoping article page model
    /// </summary>
    [ContentType(
        GUID = "70D5F29B-3828-4FD2-8ED1-4D3E753069AF", 
        GroupName = ModelsConstants.ContentTypeGroupNames.MeetInNykg)]
    [ContentTypeThumbnail(ContentTypeThumbnailConstants.ContentTypeThumbnails.GeneralPage)]
    [PageTreeIcon(PageTreeIconsConstants.ContentTypeTreeIcons.GeneralPage)]
    public class MeetInNykgArticlePageModel : SitePageData
    {
        [Display(
            Name = "Rubrik",
            Description = "Rubrik",
            GroupName = SystemTabNames.Content,
            Order = 10)]
        public virtual string Header { get; set; }

        [Display(
            Name = "Ingress",
            Description = "Ingress",
            GroupName = SystemTabNames.Content,
            Order = 15)]
        public virtual XhtmlString Extract { get; set; }

        [Display(
            Name = "Main body",
            Description = "Brödtext",
            GroupName = SystemTabNames.Content,
            Order = 1)]
        public virtual XhtmlString MainBody { get; set; }

        [Display(
            Name = "Toppbild",
            Description = "Toppbild",
            GroupName = SystemTabNames.Content,
            Order = 35)]
        public virtual ContentReference TopImage { get; set; }

        [Display(
            Name = "En kolumn",
            Description = "Sida med endast en kolumn",
            GroupName = SystemTabNames.Content,
            Order = 77)]
        public virtual bool OneColumnOnly { get; set; }

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

        [Display(
            Name = "Ange som menystart (undermeny höger)",
            GroupName = SystemTabNames.Content,
            Order = 99)]
        public virtual bool Menu { get; set; }
    }
}