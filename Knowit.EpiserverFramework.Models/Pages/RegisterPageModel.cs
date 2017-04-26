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
    /// Register page model
    /// </summary>
    [ContentType(
        GUID = "eb28e3a7-54b6-43b0-99d0-c620b5e71bdb", 
        GroupName = ModelsConstants.ContentTypeGroupNames.Admin)]
    [ContentTypeThumbnail(ContentTypeThumbnailConstants.ContentTypeThumbnails.SettingsPage)]
    [PageTreeIcon(PageTreeIconsConstants.ContentTypeTreeIcons.SettingsPage)]
    public class RegisterPageModel : SitePageData
    {
        [CultureSpecific]
        [Display(
            Name = "Brödtext",
            Description = "The main body will be shown in the main content area of the page, using the XHTML-editor you can insert for example text, images and tables.",
            GroupName = SystemTabNames.Content,
            Order = 1)]
        public virtual XhtmlString MainBody { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Användaravtal",
            Description = "Användaravtal",
            GroupName = SystemTabNames.Content,
            Order = 2)]
        public virtual XhtmlString EULA { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Ämne Välkomstmail",
            Description = "Ämne Välkomstmail",
            GroupName = SystemTabNames.Content,
            Order = 10)]
        public virtual string MailSubjectWelcome { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Välkomstmail",
            Description = "Välkomstmail",
            GroupName = SystemTabNames.Content,
            Order = 11)]
        public virtual XhtmlString MailTemplateWelcome { get; set; }

        [CultureSpecific]
        [Required]
        [Display(
            Name = "Success target page",
            Description = "Redirect user to page on successful register",
            GroupName = SystemTabNames.Content,
            Order = 12)]
        public virtual ContentReference SuccessTarget { get; set; }

        //// Non EPiServer properties 
        [Ignore]
        [Range(typeof(bool), "true", "true", ErrorMessage = "Användaravtal måste godkännas")]
        [Display(
            Name = "Användaravtal")]
        public bool ApproveEULA { get; set; }

        [Ignore]
        [Required(ErrorMessage = "{0} måste anges")]

        //// [DataType(DataType.EmailAddress)]
        [EmailAddress]
        [Display(
            Name = "Epostadress")]
        public string Email { get; set; }

        [Ignore]
        [Required(ErrorMessage = "{0} måste anges")]
        [StringLength(100, ErrorMessage = "{0} måste vara minst {2} tecken långt.", MinimumLength = 8)]
        //// [RegularExpression("^(?=.*[A-Z].*[A-Z])(?=.*[!@#$&*])(?=.*[0-9].*[0-9])(?=.*[a-z].*[a-z].*[a-z]).{8}$", ErrorMessage = "The {0} must contain atleast two uppercase letters, two digits, one special case letter and three lowercase letters.")]
        [DataType(DataType.Password)]
        [Display(
            Name = "Lösenord")]
        public string Password { get; set; }

        [Ignore]
        [DataType(DataType.Password)]
        [Display(
            Name = "Lösenordsbekräftelse")]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "Lösenordet och lösenordsbekräftelsen matchar inte.")]
        public string ConfirmPassword { get; set; }

        [Display(
            Name = "Hjälp för epost",
            Description = "Hjälp för epost",
            GroupName = "Hjälptexter",
            Order = 5)]
        public virtual XhtmlString EmailHelp { get; set; }

        [Display(
            Name = "Hjälp för lösenordet",
            Description = "Hjälp för lösenordet",
            GroupName = "Hjälptexter",
            Order = 10)]
        public virtual XhtmlString PasswordHelp { get; set; }

        [Display(
            Name = "Hjälp för lösenordet igen",
            Description = "Hjälp för lösenordet igen",
            GroupName = SiteGroupDefinitions.Helptexts,
            Order = 15)]
        public virtual XhtmlString PasswordAgainHelp { get; set; }
    }
}