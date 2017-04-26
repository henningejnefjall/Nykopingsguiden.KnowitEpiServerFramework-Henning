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
    /// Login page model
    /// </summary>
    [ContentType(
        GUID = "b815759c-c545-4c25-8dbb-67d208468a8d",
        GroupName = ModelsConstants.ContentTypeGroupNames.Admin)]
    [ContentTypeThumbnail(ContentTypeThumbnailConstants.ContentTypeThumbnails.LoginPage)]
    [PageTreeIcon(PageTreeIconsConstants.ContentTypeTreeIcons.GeneralPage)]
    public class LoginPageModel : SitePageData
    {
        [Display(
            Name = "Innehåll",
            Description = "Brödtext",
            GroupName = SystemTabNames.Content,
            Order = 1)]
        public virtual XhtmlString MainBody { get; set; }
        
        [Required(ErrorMessage = "{0} måste anges")]
        [Display(
            Name = "Inloggning målsida",
            Description = "Vidarebefordra användare till denna sida om inloggning gick vägen",
            GroupName = SystemTabNames.Content,
            Order = 1)]
        public virtual ContentReference SuccessTarget { get; set; }
        
        [Required(ErrorMessage = "{0} måste anges")]
        [Display(
            Name = "Sida för användarregistrering",
            Description = "Sida för användarregistrering",
            GroupName = SystemTabNames.Content,
            Order = 1)]
        public virtual ContentReference RegisterPage { get; set; }
        
        [Required(ErrorMessage = "{0} måste anges")]
        [Display(
            Name = "Sida för glömt lösenord",
            Description = "Sida för glömt lösenord",
            GroupName = SystemTabNames.Content,
            Order = 1)]
        public virtual ContentReference ResetPage { get; set; }
        
        [Display(
            Name = "E-postmall",
            Description = "E-postmall för återställningsmail",
            GroupName = SystemTabNames.Content,
            Order = 1)]

        public virtual XhtmlString EmailTemplate { get; set; }
        [Ignore]
        [Required(ErrorMessage = "{0} måste anges")]
        [Display(Name = "Epostadress")]
        public string Email { get; set; }

        [Ignore]
        [Required(ErrorMessage = "{0} måste anges")]
        [DataType(DataType.Password)]
        [Display(Name = "Lösenord")]
        public string Password { get; set; }
    }
}