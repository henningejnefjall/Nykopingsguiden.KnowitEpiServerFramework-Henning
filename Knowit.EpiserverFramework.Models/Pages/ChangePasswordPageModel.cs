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
    /// Change password page model
    /// </summary>
    [ContentType(
        DisplayName = "ChangePasswordPage", 
        GUID = "7c3ec2ce-0658-483d-8cc2-177424c1d1a2", 
        GroupName = ModelsConstants.ContentTypeGroupNames.Admin)]
    [ContentTypeThumbnail(ContentTypeThumbnailConstants.ContentTypeThumbnails.SettingsPage)]
    [PageTreeIcon(PageTreeIconsConstants.ContentTypeTreeIcons.SettingsPage)]
    public class ChangePasswordPageModel : SitePageData
    {
        //// Content tab

        [CultureSpecific]
        [Display(
            Name = "Main body",
            Description = "The main body will be shown in the main content area of the page, using the XHTML-editor you can insert for example text, images and tables.",
            GroupName = SystemTabNames.Content,
            Order = 1)]
        public virtual XhtmlString MainBody { get; set; }

        //// Ignored properties

        [Ignore]
        [Display(Name = "Gammalt lösenord")]
        public string OldPassword { get; set; }

        [Ignore]
        [Required(ErrorMessage = "{0} måste anges")]
        [StringLength(100, ErrorMessage = "{0} måste vara minst {2} tecken långt.", MinimumLength = 8)]
        //// [RegularExpression("^(?=.*[A-Z].*[A-Z])(?=.*[!@#$&*])(?=.*[0-9].*[0-9])(?=.*[a-z].*[a-z].*[a-z]).{8}$", ErrorMessage = "The {0} must contain atleast two uppercase letters, two digits, one special case letter and three lowercase letters.")]
        [DataType(DataType.Password)]
        [Display(Name = "Lösenord")]
        public string NewPassword { get; set; }

        [Ignore]
        [DataType(DataType.Password)]
        [Display(Name = "Lösenordsbekräftelse")]
        [System.ComponentModel.DataAnnotations.Compare("NewPassword", ErrorMessage = "Lösenordet och lösenordsbekräftelsen matchar inte.")]
        public string ConfirmPassword { get; set; }
    }
}