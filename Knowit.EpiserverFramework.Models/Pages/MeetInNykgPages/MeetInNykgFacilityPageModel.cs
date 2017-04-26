using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using Knowit.EpiserverFramework.EpiCore.Features.ContentTypeThumbnail;
using Knowit.EpiserverFramework.Models.Blocks;
using Knowit.EpiserverFramework.Models.Core;

namespace Knowit.EpiserverFramework.Models.Pages.MeetInNykgPages
{
    /// <summary>
    /// Meet in Nykopingg facility page model
    /// </summary>
    [ContentType(
        GUID = "CEEA4DED-B567-4351-8261-920E52C86389",
        GroupName = ModelsConstants.ContentTypeGroupNames.MeetInNykg)]
    [ContentTypeThumbnail(ContentTypeThumbnailConstants.ContentTypeThumbnails.CompanyPage)]
    public class MeetInNykgFacilityPageModel : SitePageData
    {
        [Display(
            GroupName = SystemTabNames.Content,
            Order = 10)]
        [AllowedTypes(typeof(ImageSlideStandardBlockModel), typeof(ImageData))]
        public virtual ContentArea ImageSlider { get; set; }

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
            Name = "Rubrik högerkolumn",
            Description = "Rubrik i högerkolumn för aktiviteter i lokalen",
            GroupName = SystemTabNames.Content,
            Order = 75)]
        public virtual string Activities { get; set; }

        [Display(
            Name = "Dölj i listningar",
            Description = "Dölj i listningar",
            GroupName = SystemTabNames.Content,
            Order = 77)]
        public virtual bool Inactive { get; set; }

        [Display(
            GroupName = SystemTabNames.Content,
            Order = 60)]
        public virtual ContentArea RightColumn { get; set; }

        [Display(
           GroupName = SystemTabNames.Content,
           Order = 80)]
        public virtual ContentArea MainColumnBottom { get; set; }

        //// Ignored properties

        [Ignore]
        public virtual string PageId { get; set; }
    }
}