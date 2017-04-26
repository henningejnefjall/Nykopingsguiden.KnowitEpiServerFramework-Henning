using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Web;
using Knowit.EpiserverFramework.EpiCore.Features.ContentTypeThumbnail;
using Knowit.EpiserverFramework.Models.Core;

namespace Knowit.EpiserverFramework.Models.Pages
{
    /// <summary>
    /// Visit page model
    /// </summary>
    [ContentType(
        DisplayName = "Besöksmål", 
        GUID = "01f7ae96-9e42-44b9-9072-f97330828034", 
        Description = "En sida för besöksmål", 
        GroupName = ModelsConstants.ContentTypeGroupNames.Events)]
    [ContentTypeThumbnail(ContentTypeThumbnailConstants.ContentTypeThumbnails.VisitPage)]
    public class VisitPageModel : SitePageData
    {
        //// Content tab

        [Display(
            Name = "Besöksmålskategorier",
            Description = "Kategorier för besöksmål",
            GroupName = SystemTabNames.Content,
            Order = 1)]
        public virtual CategoryList CompanyCategories { get; set; }

        [Display(
            Name = "Rubrik",
            Description = "Rubrik för besöksmål",
            GroupName = SystemTabNames.Content,
            Order = 10)]
        public virtual string Header { get; set; }

        [Display(
            Name = "Ingress",
            Description = "Ingress för besöksmål",
            GroupName = SystemTabNames.Content,               
            Order = 15)]
        public virtual XhtmlString Extract { get; set; }
        
        [Display(
            Name = "Main body",
            Description = "Brödtext (XHTML)",
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
            Description = "Tillgänglighet för besöksmål",
            GroupName = SystemTabNames.Content,
            Order = 21)]
        public virtual XhtmlString Access { get; set; }

        [Display(
            Name = "Adress",
            Description = "Adress för besöksmål",
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
            Name = "Bild 1",
            Description = "Första bild för besöksmål",
            GroupName = SystemTabNames.Content,
            Order = 35)]
        public virtual ContentReference Image1 { get; set; }

        [Display(
            Name = "Bild 2",
            Description = "Andra bild för besöksmål",
            GroupName = SystemTabNames.Content,
            Order = 40)]
        public virtual ContentReference Image2 { get; set; }

        [Display(
            Name = "Bild 3",
            Description = "Tredje bild för besöksmål",
            GroupName = SystemTabNames.Content,
            Order = 45)]
        public virtual ContentReference Image3 { get; set; }

        [Display(
            Name = "Dokument",
            Description = "Dokument för besöksmål",
            GroupName = SystemTabNames.Content,
            Order = 50)]
        public virtual ContentReference Document { get; set; }

        [Display(
            Name = "Webbplats",
            Description = "Webbplats för besöksmål",
            GroupName = SystemTabNames.Content,
            Order = 55)]
        public virtual string WebPage { get; set; }
        
        [Display(
            Name = "Facebook",
            Description = "Facebook för besöksmål",
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
            Description = "Tripadvisor för besöksmål",
            GroupName = SystemTabNames.Content,
            Order = 75)]
        [AllowHtml]
        [UIHint(UIHint.Textarea)]
        public virtual XhtmlString Tripadvisor { get; set; }

        //// Ignored properties

        [Ignore]
        public virtual string PageId { get; set; }
    }
}