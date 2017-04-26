using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Shell.ObjectEditing;
using EPiServer.Web;
using Knowit.EpiserverFramework.EpiCore.Features.ContentTypeThumbnail;
using Knowit.EpiserverFramework.EpiCore.Features.EnumEditorDescriptor;
using Knowit.EpiserverFramework.Models.Core;

namespace Knowit.EpiserverFramework.Models.Pages
{
    /// <summary>
    /// Company page model
    /// </summary>
    [ContentType(
        DisplayName = "CompanyPage", 
        GUID = "01fc8e96-9e72-44b9-9072-f97310828094", 
        GroupName = ModelsConstants.ContentTypeGroupNames.Events)]
    [ContentTypeThumbnail(ContentTypeThumbnailConstants.ContentTypeThumbnails.CompanyPage)]
    public class CompanyPageModel : SitePageData
    {
        //// Content tab
       
        public enum SectionChoice
        {
            Seochgora = 0,
            Ata = 1,
            Bo = 2,
            Gruppaktiviteter,
        }

        [Display(
            Name = "Verksamhetskategorier",
            Description = "Verksamhetskategorier för verksamhet",
            GroupName = SystemTabNames.Content,
            Order = 1)]
        public virtual CategoryList CompanyCategories { get; set; }

        [BackingType(typeof(PropertyNumber))]
        [EditorDescriptor(EditorDescriptorType = typeof(EnumEditorDescriptor<SectionChoice>))]
        public virtual SectionChoice SiteSection { get; set; }

        [Display(Name = "Rubrik",
            Description = "Rubrik för verksamhet",
            GroupName = SystemTabNames.Content,
            Order = 10)]
        public virtual string Header { get; set; }

        [Display(
            Name = "Ingress",
            Description = "Ingress för verksamhet",
            GroupName = SystemTabNames.Content,
            Order = 15)]
        public virtual XhtmlString Extract { get; set; }
        
        [Display(
            Name = "Main body",
            Description = "The main body will be shown in the main content area of the page, using the XHTML-editor you can insert for example text, images and tables.",
            GroupName = SystemTabNames.Content,
            Order = 20)]
        public virtual XhtmlString MainBody { get; set; }

        [Display(
            Name = "Öppettider & priser",
        Description = "Öppettider & priser för verksamhet",
        GroupName = SystemTabNames.Content,
        Order = 21)]
        public virtual XhtmlString Opening { get; set; }

        [Display(
            Name = "Tillgänglighet",
            Description = "Tillgänglighet för verksamhet",
            GroupName = SystemTabNames.Content,
            Order = 21)]
        public virtual XhtmlString Access { get; set; }

        [Display(
            Name = "Adress",
            Description = "Adress för verksamhet",
            GroupName = SystemTabNames.Content,
            Order = 25)]
        public virtual string Address { get; set; }

        [Display(
            Name = "Telefon",
            Description = "Telefon för verksamhet",
            GroupName = SystemTabNames.Content,
            Order = 30)]
        public virtual string Phone { get; set; }

        [Display(
            Name = "E-post",
            Description = "E-post för verksamhet",
            GroupName = SystemTabNames.Content,
            Order = 31)]
        public virtual string Email { get; set; }

        [Display(
            Name = "Bild 1",
            Description = "Första bild för verksamhet",
            GroupName = SystemTabNames.Content,
            Order = 35)]
        [UIHint(UIHint.Image)]
        public virtual ContentReference Image1 { get; set; }

        [Display(
            Name = "Bild 2",
            Description = "Andra bild för verksamhet",
            GroupName = SystemTabNames.Content,
            Order = 40)]
        [UIHint(UIHint.Image)]
        public virtual ContentReference Image2 { get; set; }

        [Display(
            Name = "Bild 3",
            Description = "Tredje bild för verksamhet",
            GroupName = SystemTabNames.Content,
            Order = 45)]
        [UIHint(UIHint.Image)]
        public virtual ContentReference Image3 { get; set; }

        [Display(
            Name = "Dokument",
            Description = "Dokument för verksamhet",
            GroupName = SystemTabNames.Content,
            Order = 50)]
        public virtual ContentReference Document { get; set; }

        [Display(
            Name = "Webbplats",
            Description = "Webbplats för verksamhet",
            GroupName = SystemTabNames.Content,
            Order = 55)]
        public virtual string WebPage { get; set; }

        [Display(
            Name = "Bokningssida",
            Description = "Bokningssida för verksamhet",
            GroupName = SystemTabNames.Content,
            Order = 56)]
        public virtual string BookingPage { get; set; }

        [Display(
            Name = "Facebook",
            Description = "Facebook för verksamhet",
            GroupName = SystemTabNames.Content,
            Order = 60)]
        public virtual string FacebookPage { get; set; }

        [Display(
            Name = "Latitud",
            Description = "Platsens latitudkoordinater",
            GroupName = SystemTabNames.Content,
            Order = 70)]
        public virtual string Latitude { get; set; }

        [Display(
            Name = "Longitud",
            Description = "Platsens longitudkoordinater",
            GroupName = SystemTabNames.Content,
            Order = 73)]
        public virtual string Longitude { get; set; }

        [Display(
            Name = "Tripadvisor",
            Description = "Tripadvisor för verksamheten",
            GroupName = SystemTabNames.Content,
            Order = 75)]
        [AllowHtml]
        [UIHint(UIHint.Textarea)]
        public virtual string Tripadvisor { get; set; }

        [Display(
            Name = "Inaktivera verksamhet",
            Description = "Inaktivera verksamhet",
            GroupName = SystemTabNames.Content,
            Order = 77)]
        public virtual bool Inactive { get; set; }

        [Display(
            Name = "Flagga evenemang",
            Description = "Flagga evenemang för högre prio",
            GroupName = SystemTabNames.Content,
            Order = 62)]
        public virtual bool Flag { get; set; }

        //// Settings

        [Display(
            Name = "Inaktivera verksamhet",
            Description = "Inaktivera verksamhet och omöjliggör återaktivering för användare",
            GroupName = SystemTabNames.Settings,
            Order = 77)]
        public virtual bool SuperInactive { get; set; }

        [Display(
            Name = "Ägare",
            Description = "Ägare av verksamhet",
            GroupName = SystemTabNames.Settings,
            Order = 65)]
        [Editable(false)]
        [Searchable(false)]
        public virtual string Owner { get; set; }

        //// Ignored properties

        [Ignore]
        public virtual string PageId { get; set; }
    }
}