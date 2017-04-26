using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using Knowit.EpiserverFramework.EpiCore.Features.ContentTypeThumbnail;
using Knowit.EpiserverFramework.Models.Core;

namespace Knowit.EpiserverFramework.Models.Pages
{
    /// <summary>
    /// Event page model
    /// </summary>
    [ContentType(
        DisplayName = "EventPage", 
        GUID = "01f32e96-9e72-44b9-9072-f93210828094", 
        GroupName = ModelsConstants.ContentTypeGroupNames.Events)]
    [ContentTypeThumbnail(ContentTypeThumbnailConstants.ContentTypeThumbnails.EventPage)]
    public class EventPageModel : SitePageData
    {
        [Display(
            Name = "Evenemangskategorier",
            Description = "Evenemangskategorier för evenemang",
            GroupName = SystemTabNames.Content,
            Order = 1)]
        public virtual CategoryList EventCategories { get; set; }

        [Display(
            Name = "Lokalkategorier",
            Description = "Lokalkategorier för verksamhet",
            GroupName = SystemTabNames.Content,
            Order = 5)]
        public virtual CategoryList AttractionsCategories { get; set; }

        [Display(
            Name = "Rubrik",
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
            Name = "Verksamhet",
            Description = "Verksamhet kopplad till evenemang",
            GroupName = SystemTabNames.Content,
            Order = 21)]
        public virtual PageReference Company { get; set; }

        [Display(
            Name = "Lokal",
            Description = "Lokal för evenemang",
            GroupName = SystemTabNames.Content,
            Order = 22)]
        public virtual PageReference Place { get; set; }

        [Display(
            Name = "Pris",
            Description = "Pris för evenemang",
            GroupName = SystemTabNames.Content,
            Order = 23)]
        public virtual XhtmlString Price { get; set; }

        [Display(
            Name = "Arrangör",
            Description = "Arrangör av evenemang",
            GroupName = SystemTabNames.Content,
            Order = 24)]
        public virtual string Organizer { get; set; }

        [Display(
            Name = "Länk till arrangör",
            Description = "Länk till arrangör av evenemang",
            GroupName = SystemTabNames.Content,
            Order = 25)]
        public virtual string OrganizerUrl { get; set; }

        [Display(
            Name = "Länk till bokning eller köp av biljett",
            Description = "Länk till bokning eller köp av biljett för evenemang",
            GroupName = SystemTabNames.Content,
            Order = 30)]
        public virtual string BookingUrl { get; set; }

        [Display(
            Name = "Bild 1",
            Description = "Första bild för evenemang",
            GroupName = SystemTabNames.Content,
            Order = 35)]
        public virtual ContentReference Image1 { get; set; }

        [Display(
            Name = "Dokument",
            Description = "Dokument för evenemang",
            GroupName = SystemTabNames.Content,
            Order = 50)]
        public virtual ContentReference Document { get; set; }

        [Display(
            Name = "Annan lokal/plats",
            Description = "Annan lokal/plats för evenemang",
            GroupName = SystemTabNames.Content,
            Order = 57)]
        public virtual string OtherPlace { get; set; }

        [Display(
            Name = "Tillgänglighet",
        Description = "Tillgänglighet för evenemang",
        GroupName = SystemTabNames.Content,
        Order = 59)]
        public virtual XhtmlString Access { get; set; }

        [Display(
            Name = "Facebook",
            Description = "Facebook för verksamhet",
            GroupName = SystemTabNames.Content,
            Order = 60)]
        public virtual string FacebookPage { get; set; }

        [Display(
            Name = "E-post",
            Description = "E-post till verksamhet",
            GroupName = SystemTabNames.Content,
            Order = 60)]
        public virtual string Email { get; set; }

        [Display(
            Name = "Flagga evenemang",
            Description = "Flagga evenemang för högre prio",
            GroupName = SystemTabNames.Content,
            Order = 62)]
        public virtual bool Flag { get; set; }

        [Display(
            Name = "Dölj evenemang i lista",
            Description = "Dölj evenemang i lista",
            GroupName = SystemTabNames.Content,
            Order = 64)]
        public virtual bool HideList { get; set; }

        [Display(
            Name = "Dölj evenemang i karuseller",
            Description = "Dölj evenemang i karuseller",
            GroupName = SystemTabNames.Content,
            Order = 64)]
        public virtual bool HideCarousel { get; set; }

        [Display(
            Name = "Ägare",
            Description = "Ägare av verksamhet",
            GroupName = SystemTabNames.Settings,
            Order = 65)]
        [Editable(false)]
        public virtual string Owner { get; set; }

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

        [Ignore]
        public virtual string PageId { get; set; }
    }
}