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
    /// Article page model
    /// </summary>
    [ContentType(
        GUID = "701fe292-d5bd-4e87-a535-27fb5863f4a5",
        GroupName = ModelsConstants.ContentTypeGroupNames.PageType)]
    [ContentTypeThumbnail(ContentTypeThumbnailConstants.ContentTypeThumbnails.GeneralPage)]
    [PageTreeIcon(PageTreeIconsConstants.ContentTypeTreeIcons.GeneralPage)]
    public class ArticlePageModel : SitePageData
    {
        [Display(
            Name = "Rubrik",
            Description = "Rubrik",
            GroupName = SystemTabNames.Content,
            Order = 10)]
        public virtual string Header { get; set; }

        [Display(Name = "Ingress",
            Description = "Ingress",
            GroupName = SystemTabNames.Content,
            Order = 15)]
        public virtual XhtmlString Extract { get; set; }

        [Display(
            Name = "Main body",
            Description = "Brödtext",
            GroupName = SystemTabNames.Content,
            Order = 20)]
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
            Order = 98)]
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
          Name = "Ange som menystart (undermeny högerkolumn)",
          GroupName = SystemTabNames.Content,
          Order = 99)]
        public virtual bool Menu { get; set; }
    }
}