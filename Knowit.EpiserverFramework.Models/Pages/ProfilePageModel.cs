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
    /// Profile page model
    /// </summary>
    [ContentType(GUID = "40b213d6-4601-480f-b1c3-a9169a849e94",
        GroupName = ModelsConstants.ContentTypeGroupNames.Admin)]
    [ContentTypeThumbnail(ContentTypeThumbnailConstants.ContentTypeThumbnails.SettingsPage)]
    [PageTreeIcon(PageTreeIconsConstants.ContentTypeTreeIcons.SettingsPage)]
    public class ProfilePageModel : SitePageData
    {
        [Display(
            Name = "Innehåll",
            Description = "Brödtext",
            GroupName = SystemTabNames.Content,
            Order = 1)]
        public virtual XhtmlString MainBody { get; set; }

        [Ignore]
        [Display(
            Name = "Förnamn")]
        public string FirstName { get; set; }

        [Ignore]
        [Display(
            Name = "Efternamn")]
        public string LastName { get; set; }

        [Ignore]
        [Display(
            Name = "Företag")]
        public string Company { get; set; }

        [Ignore]
        [Display(
            Name = "Postadress")]
        public string Address { get; set; }

        [Ignore]
        [Display(
            Name = "Postnummer")]
        public string ZipCode { get; set; }

        [Ignore]
        [Display(
            Name = "Postort")]
        public string Locality { get; set; }

        [Ignore]
        [EmailAddress]
        [Display(
            Name = "Epostadress")]
        public string Email { get; set; }
    }
}