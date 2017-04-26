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
    /// Event create page model
    /// </summary>
    [ContentType(
        DisplayName = "EventCreatePage", 
        GUID = "37f33d01-adf0-472a-b323-6e5121f6ef2d", 
        GroupName = ModelsConstants.ContentTypeGroupNames.Admin)]
    [ContentTypeThumbnail(ContentTypeThumbnailConstants.ContentTypeThumbnails.SettingsPage)]
    [PageTreeIcon(PageTreeIconsConstants.ContentTypeTreeIcons.SettingsPage)]
    public class EventCreatePageModel : SitePageData
    {
        [Display(
            Name = "Listningssida",
            Description = "Listningssida",
            GroupName = SystemTabNames.Content,
            Order = 1)]
        public virtual PageReference SuccessTarget { get; set; }

        [Display(
            Name = "Evenemangskategori",
            Description = "Rubrik för 'Evenemangskategori'",
            GroupName = SystemTabNames.Content,
            Order = 4)]
        public virtual string EventCategoryHeader { get; set; }

        [Display(
            Name = "Evenemangskategorier",
            Description = "Välj kategorier för 'Evenemangskategori'",
            GroupName = SystemTabNames.Content,
            Order = 6)]
        public virtual CategoryList EventCategories { get; set; }

        [Display(
            Name = "Besöksmålskategori",
            Description = "Rubrik för 'Besöksmålskategori'",
            GroupName = SystemTabNames.Content,
            Order = 8)]
        public virtual string AttractionsCategoryHeader { get; set; }

        [Display(
            Name = "Besöksmålskategorier",
            Description = "Välj kategorier för 'Besöksmålskategori'",
            GroupName = SystemTabNames.Content,
            Order = 10)]
        public virtual CategoryList AttractionsCategories { get; set; }

        [Display(
            Name = "Rubrik",
            Description = "Rubrik för 'Rubrik'",
            GroupName = SystemTabNames.Content,
            Order = 12)]
        public virtual string HeaderHeader { get; set; }

        [Required(ErrorMessage = "{0} måste anges")]
        [Display(
            Name = "Rubrik")]
        public virtual string Header { get; set; }

        [Display(
            Name = "Ingress",
            Description = "Rubrik för 'Ingress'",
            GroupName = SystemTabNames.Content,
            Order = 15)]
        public virtual string ExtractHeader { get; set; }

        [Ignore]
        [Required(ErrorMessage = "{0} måste anges")]
        [Display(
            Name = "Ingress")]
        public virtual string Extract { get; set; }

        [Display(
            Name = "Innehåll",
            Description = "Rubrik för 'Innehåll'",
            GroupName = SystemTabNames.Content,
            Order = 20)]
        public virtual string MainBodyHeader { get; set; }

        [Ignore]
        [Required(ErrorMessage = "{0} måste anges")]
        [Display(
            Name = "Innehåll")]
        public virtual string MainBody { get; set; }

        [Display(
            Name = "Priser",
            Description = "Rubrik för 'Priser'",
            GroupName = SystemTabNames.Content,
            Order = 21)]
        public virtual string PriceHeader { get; set; }

        [Display(
            Name = "Verksamhet",
            Description = "Rubrik för 'Verksamhet'",
            GroupName = SystemTabNames.Content,
            Order = 22)]
        public virtual string CompanyHeader { get; set; }

        [Display(
            Name = "Lokal",
            Description = "Rubrik för 'Lokal'",
            GroupName = SystemTabNames.Content,
            Order = 25)]
        public virtual string PlaceHeader { get; set; }

        [Ignore]
        [Display(
            Name = "Annan lokal")]
        public virtual string OtherPlace { get; set; }

        [Ignore]
        [Display(
            Name = "Priser")]
        public virtual string Price { get; set; }

        [Display(
            Name = "Arrangör",
            Description = "Rubrik för 'Arrangör'",
            GroupName = SystemTabNames.Content,
            Order = 31)]
        public virtual string OrganizerHeader { get; set; }

        [Ignore]
        [Display(
            Name = "Arrangör")]
        public virtual string Organizer { get; set; }

        [Display(
            Name = "Länk till arrangör",
            Description = "Rubrik för 'Länk till arrangör'",
            GroupName = SystemTabNames.Content,
            Order = 32)]
        public virtual string OrganizerUrlHeader { get; set; }

        [Ignore]
        [Display(
            Name = "Länk till arrangör")]
        public virtual string OrganizerUrl { get; set; }

        [Display(
            Name = "Länk till bokning eller köp av biljett",
            Description = "Rubrik för 'Länk till bokning eller köp av biljett för evenemang'",
            GroupName = SystemTabNames.Content,
            Order = 33)]
        public virtual string BookingUrlHeader { get; set; }

        [Ignore]
        [Display(
            Name = "Länk till bokning eller köp av biljett")]
        public virtual string BookingUrl { get; set; }

        [Display(
            Name = "Bild 1",
            Description = "Rubrik för 'Första bild'",
            GroupName = SystemTabNames.Content,
            Order = 35)]
        public virtual string Image1Header { get; set; }

        [Display(
            Name = "Dokument",
            Description = "Rubrik för 'Dokument'",
            GroupName = SystemTabNames.Content,
            Order = 50)]
        public virtual string DocumentHeader { get; set; }

        [Display(
            Name = "Annan lokal/plats",
            Description = "Rubrik för 'Annan lokal/plats för evenemang'",
            GroupName = SystemTabNames.Content,
            Order = 57)]
        public virtual string OtherPlaceHeader { get; set; }

        [Display(
            Name = "Tillgänglighet",
            Description = "Rubrik för 'Tillgänglighet för evenemang'",
            GroupName = SystemTabNames.Content,
            Order = 59)]
        public virtual string AccessHeader { get; set; }

        [Ignore]
        [Display(
            Name = "Tillgänglighet")]
        public virtual string Access { get; set; }

        [Display(
            Name = "Facebook",
            Description = "Rubrik för 'Facebook'",
            GroupName = SystemTabNames.Content,
            Order = 60)]
        public virtual string FacebookPageHeader { get; set; }

        [Ignore]
        public virtual string Facebook { get; set; }

        [Display(
            Name = "E-post",
            Description = "Rubrik för 'E-post'",
            GroupName = SystemTabNames.Content,
            Order = 60)]
        public virtual string EmailHeader { get; set; }

        [Ignore]
        public virtual string Email { get; set; }

        [Ignore]
        public virtual bool Publish { get; set; }

        [Display(
            Name = "Flagga evenemang",
            Description = "Rubrik för 'Flagga evenemang för högre prio'",
            GroupName = SystemTabNames.Content,
            Order = 62)]
        public virtual bool FlagHeader { get; set; }

        [Display(
            Name = "Dölj evenemang i lista",
            Description = "Rubrik för 'Dölj evenemang i lista'",
            GroupName = SystemTabNames.Content,
            Order = 63)]
        public virtual bool HideListHeader { get; set; }

        [Display(
            Name = "Dölj evenemang i karuseller",
            Description = "Rubrik för 'Dölj evenemang i karuseller'",
            GroupName = SystemTabNames.Content,
            Order = 64)]
        public virtual bool HideCarouselHeader { get; set; }

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
            Name = "Hjälp för evenemangskategorier",
            Description = "Hjälp för evenemangskategorier",
            GroupName = "Hjälptexter",
            Order = 5)]
        public virtual XhtmlString EventCategoryHelp { get; set; }

        [Display(
            Name = "Hjälp för loginkategorier",
            Description = "Hjälp för loginkategorier",
            GroupName = "Hjälptexter",
            Order = 10)]
        public virtual XhtmlString AttractionsCategoryHelp { get; set; }

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
            Name = "Hjälp för verksamhet",
            Description = "Hjälp för verksamhet",
            GroupName = "Hjälptexter",
            Order = 26)]
        public virtual XhtmlString CompanyHelp { get; set; }

        [Display(
            Name = "Hjälp för lokal",
            Description = "Hjälp för lokal",
            GroupName = "Hjälptexter",
            Order = 27)]
        public virtual XhtmlString PlaceHelp { get; set; }

        [Display(
            Name = "Hjälp för priser",
            Description = "Hjälp för priser",
            GroupName = "Hjälptexter",
            Order = 28)]
        public virtual XhtmlString PriceHelp { get; set; }

        [Display(
            Name = "Hjälp för tillgänglighet",
            Description = "Hjälp för tillgänglighet",
            GroupName = "Hjälptexter",
            Order = 29)]
        public virtual XhtmlString AccessHelp { get; set; }

        [Display(
            Name = "Hjälp för arrangör",
            Description = "Hjälp för arrangör",
            GroupName = "Hjälptexter",
            Order = 30)]
        public virtual XhtmlString OrganizerHelp { get; set; }

        [Display(
            Name = "Hjälp för länk till arrangör",
            Description = "Hjälp för länk till arrangör",
            GroupName = "Hjälptexter",
            Order = 35)]
        public virtual XhtmlString OrganizerUrlHelp { get; set; }

        [Display(
            Name = "Hjälp för huvudbild",
            Description = "Hjälp för huvudbild",
            GroupName = "Hjälptexter",
            Order = 40)]
        public virtual XhtmlString Image1Help { get; set; }

        [Display(
            Name = "Hjälp för länk till bokning eller köp av biljett",
            Description = "Hjälp för länk till bokning eller köp av biljett",
            GroupName = "Hjälptexter",
            Order = 45)]
        public virtual XhtmlString BookingUrlHelp { get; set; }

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
            Name = "Hjälp för e-post",
            Description = "Hjälp för e-post",
            GroupName = "Hjälptexter",
            Order = 65)]
        public virtual XhtmlString EmailHelp { get; set; }

        [Display(Name = "Hjälp för Tripadvisor",
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