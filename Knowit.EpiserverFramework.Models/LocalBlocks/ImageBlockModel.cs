using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Web;
using Knowit.EpiserverFramework.Models.Core;

namespace Knowit.EpiserverFramework.Models.LocalBlocks
{
    /// <summary>
    /// Image block model
    /// Image, alt and title
    /// </summary>
    [SiteContentType(
        GUID = "09854019-91A5-4B93-8623-17F038346001",
        GroupName = ModelsConstants.ContentTypeGroupNames.LocalBlock,
        AvailableInEditMode = false)]
    public class ImageBlockModel : SiteLocalBlockData
    {
        //// Content tab
        
        [Required(ErrorMessage = "Bild måste anges")]
        [Display(
            GroupName = SystemTabNames.Content,
            Order = 10)]
        [UIHint(UIHint.MediaFile)]
        public virtual ContentReference Image { get; set; }

        [Display(
            GroupName = SystemTabNames.Content,
            Order = 30)]
        [CultureSpecific]
        public virtual string Alt { get; set; }

        [Display(
            GroupName = SystemTabNames.Content,
            Order = 40)]
        [CultureSpecific]
        public virtual string Title { get; set; }
    }
}
