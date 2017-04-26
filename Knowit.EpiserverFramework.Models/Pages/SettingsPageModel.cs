using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using Knowit.EpiserverFramework.EpiCore.Features.ContentTypeThumbnail;
using Knowit.EpiserverFramework.EpiCore.Features.PageTreeIcons;
using Knowit.EpiserverFramework.Models.Core;

namespace Knowit.EpiserverFramework.Models.Pages
{
    /// <summary>
    /// Settings page model
    /// </summary>
    [ContentType(
        GUID = "20d29153-1aea-48ff-aa21-32966635a565", 
        GroupName = ModelsConstants.ContentTypeGroupNames.Special)]
    [ContentTypeThumbnail(ContentTypeThumbnailConstants.ContentTypeThumbnails.SettingsPage)]
    [PageTreeIcon(PageTreeIconsConstants.ContentTypeTreeIcons.SettingsPage)]
    public class SettingsPageModel : SitePageData
    {
        [Display(
            Name = "Toppmeny",
            Description = "De sidor som ska synas i toppmenyn",
            GroupName = SiteGroupDefinitions.Content,
            Order = 5)]
        public virtual LinkItemCollection TopMenu { get; set; }

        [Display(
            Name = "Mobil plus meny",
            Description = "De sidor som ska synas nederst i mobilmenyn",
            GroupName = SiteGroupDefinitions.Content,
            Order = 10)]
        public virtual LinkItemCollection PortPlusMenu { get; set; }

        [Display(
           Name = "Huvudmeny val 1",
           Description = "Första sidan som ska synas i huvudmenyn",
           GroupName = SiteGroupDefinitions.Content,
           Order = 12)]
        public virtual PageReference MainMenuItem1 { get; set; }

        [Display(
           Name = "Huvudmeny val 2",
           Description = "Andra sidan som ska synas i huvudmenyn",
           GroupName = SiteGroupDefinitions.Content,
           Order = 14)]
        public virtual PageReference MainMenuItem2 { get; set; }

        [Display(
           Name = "Huvudmeny val 3",
           Description = "Tredje sidan som ska synas i huvudmenyn",
           GroupName = SiteGroupDefinitions.Content,
           Order = 16)]
        public virtual PageReference MainMenuItem3 { get; set; }

        [Display(
           Name = "Huvudmeny val 4",
           Description = "Fjärde sidan som ska synas i huvudmenyn",
           GroupName = SiteGroupDefinitions.Content,
           Order = 18)]
        public virtual PageReference MainMenuItem4 { get; set; }

        [Display(
           Name = "Bottenmeny",
           Description = "De sidor som ska synas i bottenmenyn",
           GroupName = SiteGroupDefinitions.Content,
           Order = 20)]
        public virtual LinkItemCollection BottomMenu { get; set; }

        [Display(
           Name = "Footertext",
           Description = "De sidor som ska synas i bottenmenyn",
           GroupName = SiteGroupDefinitions.Content,
           Order = 25)]
        public virtual XhtmlString FooterText { get; set; }

        [Display(
           Name = "Söksida",
           Description = "Söksida",
           GroupName = SiteGroupDefinitions.Content,
           Order = 27)]
        public virtual PageReference SearchReference { get; set; }

        [Display(
            Name = "Mötesplats Nyköping startsida",
            Description = "Mötesplats Nyköping startsida",
            GroupName = SiteGroupDefinitions.MeetInNykg,
            Order = 1)]
        public virtual PageReference MeetInNykgStart { get; set; }

        [Display(
           Name = "Söksida",
           Description = "Söksida",
           GroupName = SiteGroupDefinitions.MeetInNykg,
           Order = 3)]
        public virtual PageReference SearchMeetInNykgReference { get; set; }

        [Display(
            Name = "Toppmeny",
            Description = "De sidor som ska synas i toppmenyn",
            GroupName = SiteGroupDefinitions.MeetInNykg,
            Order = 5)]
        public virtual LinkItemCollection MNTopMenu { get; set; }

        [Display(
            Name = "Mobil plus meny",
            Description = "De sidor som ska synas nederst i mobilmenyn",
            GroupName = SiteGroupDefinitions.MeetInNykg,
            Order = 10)]
        public virtual LinkItemCollection MNPortPlusMenu { get; set; }

        [Display(
           Name = "Huvudmeny val 1",
           Description = "Första sidan som ska synas i huvudmenyn",
           GroupName = SiteGroupDefinitions.MeetInNykg,
           Order = 12)]
        public virtual PageReference MNMainMenuItem1 { get; set; }

        [Display(
           Name = "Huvudmeny val 2",
           Description = "Andra sidan som ska synas i huvudmenyn",
           GroupName = SiteGroupDefinitions.MeetInNykg,
           Order = 14)]
        public virtual PageReference MNMainMenuItem2 { get; set; }

        [Display(
           Name = "Huvudmeny val 3",
           Description = "Tredje sidan som ska synas i huvudmenyn",
           GroupName = SiteGroupDefinitions.MeetInNykg,
           Order = 16)]
        public virtual PageReference MNMainMenuItem3 { get; set; }

        [Display(
           Name = "Huvudmeny val 4",
           Description = "Fjärde sidan som ska synas i huvudmenyn",
           GroupName = SiteGroupDefinitions.MeetInNykg,
           Order = 18)]
        public virtual PageReference MNMainMenuItem4 { get; set; }

        [Display(
            Name = "Adminmeny",
            Description = "De sidor som ska synas i adminmenyn",
            GroupName = SiteGroupDefinitions.Admin,
            Order = 5)]
        public virtual LinkItemCollection AdminMenu { get; set; }

        [Display(
            Name = "Byt lösenord",
            Description = "Sida för att byta lösenord",
            GroupName = SiteGroupDefinitions.Admin,
            Order = 6)]
        public virtual PageReference ChangePasswordPage { get; set; }

        [Display(
            Name = "Verksamheter",
            Description = "Hållare för verksamheter",
            GroupName = SiteGroupDefinitions.Admin,
            Order = 8)]
        public virtual PageReference CompanyContainerPage { get; set; }

        [Display(
            Name = "Evenemang",
            Description = "Hållare för evenemang",
            GroupName = SiteGroupDefinitions.Admin,
            Order = 10)]
        public virtual PageReference EventContainerPage { get; set; }

        [Display(
            Name = "Lokaler",
            Description = "Hållare för lokaler",
            GroupName = SiteGroupDefinitions.Admin,
            Order = 12)]
        public virtual PageReference PlacesContainerPage { get; set; }

        [Display(
            Name = "Skapa verksamheter",
            Description = "Hållare för skapa verksamheter",
            GroupName = SiteGroupDefinitions.Admin,
            Order = 15)]
        public virtual PageReference CompanyCreateContainer { get; set; }

        [Display(
            Name = "Skapa evenemang",
            Description = "Hållare för skapa evenemang",
            GroupName = SiteGroupDefinitions.Admin,
            Order = 20)]
        public virtual PageReference EventCreateContainer { get; set; }
    }
}