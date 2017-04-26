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
    /// Company list page model
    /// </summary>
    [ContentType(
        DisplayName = "CompanyListPage", 
        GUID = "2e7ea8f5-9a70-438c-8b7e-7cc1136016a9", 
        GroupName = ModelsConstants.ContentTypeGroupNames.Admin)]
    [ContentTypeThumbnail(ContentTypeThumbnailConstants.ContentTypeThumbnails.SubPageListPage)]
    [PageTreeIcon(PageTreeIconsConstants.ContentTypeTreeIcons.SubPageListPage)]
    public class CompanyListPageModel : SitePageData
    {
        //// Content tab

        [Display(
            Name = "Main body",
            Description = "The main body will be shown in the main content area of the page, using the XHTML-editor you can insert for example text, images and tables.",
            GroupName = SystemTabNames.Content,
            Order = 1)]
        public virtual XhtmlString MainBody { get; set; }

        [Display(
           Name = "Plats för verksamheter",
           Description = "Plats för verksamheter",
           GroupName = SystemTabNames.Content,
           Order = 10)]
        public virtual PageReference CompanyContainer { get; set; }

        [Display(
          Name = "Plats för evenemang",
          Description = "Plats för evenemang",
          GroupName = SystemTabNames.Content,
          Order = 15)]
        public virtual PageReference EventContainer { get; set; }

        [Display(
           Name = "Plats för Skapa verksamhet",
           Description = "Plats för Skapa verksamheter",
           GroupName = SystemTabNames.Content,
           Order = 20)]
        public virtual PageReference CompanyCreateContainer { get; set; }

        [Display(
           Name = "Plats för Skapa evenemang",
           Description = "Plats för Skapa evenemang",
           GroupName = SystemTabNames.Content,
           Order = 20)]
        public virtual PageReference EventCreateContainer { get; set; }
    }
}