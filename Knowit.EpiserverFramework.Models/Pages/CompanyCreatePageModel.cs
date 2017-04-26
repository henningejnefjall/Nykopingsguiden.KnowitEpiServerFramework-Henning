using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Shell.ObjectEditing;
using Knowit.EpiserverFramework.EpiCore.Features.ContentTypeThumbnail;
using Knowit.EpiserverFramework.EpiCore.Features.EnumEditorDescriptor;
using Knowit.EpiserverFramework.EpiCore.Features.PageTreeIcons;
using Knowit.EpiserverFramework.Models.Core;

namespace Knowit.EpiserverFramework.Models.Pages
{
    /// <summary>
    /// Company create page model
    /// </summary>
    [ContentType(
        DisplayName = "CompanyCreatePage", 
        GUID = "37fe3d01-adf0-47da-b123-6e5155f6ef2d", 
        GroupName = ModelsConstants.ContentTypeGroupNames.Admin)]
    [ContentTypeThumbnail(ContentTypeThumbnailConstants.ContentTypeThumbnails.SettingsPage)]
    [PageTreeIcon(PageTreeIconsConstants.ContentTypeTreeIcons.SettingsPage)]
    public class CompanyCreatePageModel : SitePageData
    {
        //// Content tab

        [Display(Name = "Listningssida för verksamheter",
            Description = "Listningssida för verksamheter",
            GroupName = SystemTabNames.Content,
            Order = 1)]
        public virtual PageReference SuccessTarget { get; set; }

        [Display(Name = "Verksamhetskategori",
            Description = "Rubrik för 'Verksamhetskategori'",
            GroupName = SystemTabNames.Content,
            Order = 4)]
        public virtual string CompanyCategoryHeader { get; set; }

        [Display(
            Name = "Besöksmålskategori",
            Description = "Rubrik för 'Besöksmålskategori'",
            GroupName = SystemTabNames.Content,
            Order = 8)]
        public virtual string AttractionsCategoryHeader { get; set; }

        [BackingType(typeof(PropertyNumber))]
        [EditorDescriptor(EditorDescriptorType = typeof(EnumEditorDescriptor<CompanyPageModel.SectionChoice>))]
        public virtual CompanyPageModel.SectionChoice SiteSection { get; set; }

        [Display(
            Name = "Rubrik",
            Description = "Rubrik för 'Rubrik'",
            GroupName = SystemTabNames.Content,
            Order = 12)]
        public virtual string HeaderHeader { get; set; }

        [Required(ErrorMessage = "{0} måste anges")]
        [Display(Name = "Rubrik")]
        public virtual string Header { get; set; }

        [Display(
            Name = "Ingress",
            Description = "Rubrik för 'Ingress'",
            GroupName = SystemTabNames.Content,
            Order = 15)]
        public virtual string ExtractHeader { get; set; }

        [Ignore]
        [Display(Name = "Ingress")]
        [Required(ErrorMessage = "{0} måste anges")]
        public virtual string Extract { get; set; }

        [Display(
            Name = "Innehåll",
            Description = "Rubrik för 'Innehåll'",
            GroupName = SystemTabNames.Content,
            Order = 20)]
        public virtual string MainBodyHeader { get; set; }

        [Ignore]
        [Display(Name = "Innehåll")]
        [Required(ErrorMessage = "{0} måste anges")]
        public virtual string MainBody { get; set; }

        [Display(
            Name = "Öppettider & priser",
            Description = "Rubrik för 'Öppettider & priser'",
            GroupName = SystemTabNames.Content,
            Order = 21)]
        public virtual string OpeningHeader { get; set; }

        [Ignore]
        [Display(Name = "Öppettider & priser")]
        public virtual string Opening { get; set; }

        [Display(
            Name = "Tillgänglighet",
            Description = "Rubrik för 'Tillgänglighet'",
            GroupName = SystemTabNames.Content,
            Order = 23)]
        public virtual string AccessHeader { get; set; }

        [Ignore]
        [Display(Name = "Tillgänglighet")]
        public virtual string Access { get; set; }

        [Display(
            Name = "Adress",
            Description = "Rubrik för 'Adress'",
            GroupName = SystemTabNames.Content,
            Order = 25)]
        public virtual string AddressHeader { get; set; }

        public virtual string Address { get; set; }

        [Display(
            Name = "Telefon",
            Description = "Rubrik för 'Telefon'",
            GroupName = SystemTabNames.Content,
            Order = 30)]
        public virtual string PhoneHeader { get; set; }

        public virtual string Phone { get; set; }

        [Display(
            Name = "E-post",
            Description = "Rubrik för 'E-post'",
            GroupName = SystemTabNames.Content,
            Order = 31)]
        public virtual string EmailHeader { get; set; }

        public virtual string Email { get; set; }

        [Display(
            Name = "Bild 1",
            Description = "Rubrik för 'Första bild'",
            GroupName = SystemTabNames.Content,
            Order = 35)]
        public virtual string Image1Header { get; set; }

        [Display(
            Name = "Bild 2",
            Description = "Rubrik för 'Andra bild'",
            GroupName = SystemTabNames.Content,
            Order = 40)]
        public virtual string Image2Header { get; set; }

        [Display(
            Name = "Bild 3",
            Description = "Rubrik för 'Tredje bild'",
            GroupName = SystemTabNames.Content,
            Order = 45)]
        public virtual string Image3Header { get; set; }

        [Display(
            Name = "Dokument",
            Description = "Rubrik för 'Dokument'",
            GroupName = SystemTabNames.Content,
            Order = 50)]
        public virtual string DocumentHeader { get; set; }

        [Display(
            Name = "Webbplats",
            Description = "Rubrik för 'Webbplats'",
            GroupName = SystemTabNames.Content,
            Order = 55)]
        public virtual string WebPageHeader { get; set; }

        [Ignore]
        public virtual string WebPage { get; set; }

        [Display(
            Name = "Facebook",
            Description = "Rubrik för 'Facebook'",
            GroupName = SystemTabNames.Content,
            Order = 60)]
        public virtual string FacebookPageHeader { get; set; }

        [Ignore]
        public virtual string Facebook { get; set; }

        [Display(
            Name = "Bokningssida",
            Description = "Rubrik för 'bokningssida'",
            GroupName = SystemTabNames.Content,
            Order = 61)]
        public virtual string BookingPageHeader { get; set; }

        [Ignore]
        public virtual string BookingPage { get; set; }

        [Display(
            Name = "Karta",
            Description = "Rubrik för kartan",
            GroupName = SystemTabNames.Content,
            Order = 65)]
        public virtual string MapHeader { get; set; }

        [Ignore]
        public virtual string Latitude { get; set; }

        [Ignore]
        public virtual string Longitude { get; set; }

        [Display(
            Name = "Tripadvisor",
            Description = "Rubrik för Tripadvisor",
            GroupName = SystemTabNames.Content,
            Order = 70)]
        public virtual string TripadvisorHeader { get; set; }

        [Ignore]
        [AllowHtml]
        public virtual string Tripadvisor { get; set; }

        [Ignore]
        public virtual string PageId { get; set; }

        [Ignore]
        public virtual string DefaultLat { get; set; }

        [Ignore]
        public virtual string DefaultLong { get; set; }

        [Display(
            Name = "Övre innehåll",
            Description = "Övre innehåll på första sidan",
            GroupName = SystemTabNames.Content,
            Order = 72)]
        public virtual XhtmlString UpperFirstMainBody { get; set; }

        [Display(
            Name = "Nedre innehåll",
            Description = "Nedre innehåll på första sidan",
            GroupName = SystemTabNames.Content,
            Order = 75)]
        public virtual XhtmlString LowerFirstMainBody { get; set; }

        [Display(
            Name = "Övre andra innehåll",
            Description = "Övre innehåll på andra sidan",
            GroupName = SystemTabNames.Content,
            Order = 82)]
        public virtual XhtmlString UpperSecondMainBody { get; set; }

        [Display(
            Name = "Nedre andra innehåll",
            Description = "Nedre innehåll på andra sidan",
            GroupName = SystemTabNames.Content,
            Order = 85)]
        public virtual XhtmlString LowerSecondMainBody { get; set; }

        [Display(
            Name = "Hjälp för verksamhetskategorier",
            Description = "Hjälp för verksamhetskategorier",
            GroupName = "Hjälptexter",
            Order = 5)]
        public virtual XhtmlString CompanyCategoryHelp { get; set; }

        [Display(
            Name = "Hjälp för loginkategorier",
            Description = "Hjälp för loginkategorier",
            GroupName = "Hjälptexter",
            Order = 10)]
        public virtual XhtmlString ConferenceCategoryHelp { get; set; }

        [Display(
            Name = "Hjälp för rubrik",
            Description = "Hjälp för rubrik",
            GroupName = "Hjälptexter",
            Order = 15)]
        public virtual XhtmlString HeaderHelp { get; set; }

        [Display(
            Name = "Hjälp för ingress",
            Description = "Hjälp för ingress",
            GroupName = "Hjälptexter",
            Order = 20)]
        public virtual XhtmlString ExtractHelp { get; set; }

        [Display(
            Name = "Hjälp för innehåll",
            Description = "Hjälp för innehåll",
            GroupName = "Hjälptexter",
            Order = 25)]
        public virtual XhtmlString MainbodyHelp { get; set; }

        [Display(
            Name = "Hjälp för öppettider & priser",
            Description = "Hjälp för öppettider & priser",
            GroupName = "Hjälptexter",
            Order = 25)]
        public virtual XhtmlString OpeningHelp { get; set; }

        [Display(
            Name = "Hjälp för tillgänglighet",
            Description = "Hjälp för tillgänglighet",
            GroupName = "Hjälptexter",
            Order = 25)]
        public virtual XhtmlString AccessHelp { get; set; }

        [Display(
            Name = "Hjälp för adress",
            Description = "Hjälp för adress",
            GroupName = "Hjälptexter",
            Order = 30)]
        public virtual XhtmlString AddressHelp { get; set; }

        [Display(
            Name = "Hjälp för telefon",
            Description = "Hjälp för telefon",
            GroupName = "Hjälptexter",
            Order = 35)]
        public virtual XhtmlString PhoneHelp { get; set; }

        [Display(
            Name = "Hjälp för e-post",
            Description = "Hjälp för epost'",
            GroupName = SystemTabNames.Content,
            Order = 36)]
        public virtual string EmailHelp { get; set; }

        [Display(
            Name = "Hjälp för huvudbild",
            Description = "Hjälp för huvudbild",
            GroupName = "Hjälptexter",
            Order = 40)]
        public virtual XhtmlString Image1Help { get; set; }

        [Display(
            Name = "Hjälp för andrabild",
            Description = "Hjälp för andrabild",
            GroupName = "Hjälptexter",
            Order = 45)]
        public virtual XhtmlString Image2Help { get; set; }

        [Display(
            Name = "Hjälp för tredjebild",
            Description = "Hjälp för tredjebild",
            GroupName = "Hjälptexter",
            Order = 50)]
        public virtual XhtmlString Image3Help { get; set; }

        [Display(
            Name = "Hjälp för dokument",
            Description = "Hjälp för dokument",
            GroupName = "Hjälptexter",
            Order = 55)]
        public virtual XhtmlString DocumentHelp { get; set; }

        [Display(
            Name = "Hjälp för webbplats",
            Description = "Hjälp för webbplats",
            GroupName = "Hjälptexter",
            Order = 60)]
        public virtual XhtmlString WebpageHelp { get; set; }

        [Display(
            Name = "Hjälp för facebook",
            Description = "Hjälp för facebook",
            GroupName = "Hjälptexter",
            Order = 65)]
        public virtual XhtmlString FacebookpageHelp { get; set; }

        [Display(
            Name = "Hjälp för bokningssida",
            Description = "Hjälp för bokningssida",
            GroupName = "Hjälptexter",
            Order = 66)]
        public virtual XhtmlString BookingpageHelp { get; set; }

        [Display(
            Name = "Hjälp för Tripadvisor",
            Description = "Hjälp för Tripadvisor",
            GroupName = "Hjälptexter",
            Order = 70)]
        public virtual XhtmlString TripadvisorHelp { get; set; }

        [Display(
            Name = "Hjälp för karta",
            Description = "Hjälp för karta",
            GroupName = "Hjälptexter",
            Order = 75)]
        public virtual XhtmlString MapHelp { get; set; } 
    }
}