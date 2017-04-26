using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web;
using Knowit.EpiserverFramework.EpiCore.Features.ContentTypeThumbnail;
using Knowit.EpiserverFramework.EpiCore.Features.PageTreeIcons;

namespace Knowit.EpiserverFramework.Models.Media
{
    /// <summary>
    /// Image media model
    /// </summary>
    [ContentType(
        GUID = "8d89d833-a236-481b-a2b6-4e6fab386205")]
    [MediaDescriptor(ExtensionString = "jpg,jpeg,jpe,ico,gif,bmp,png,svg")]
    [ContentTypeThumbnail(PageTreeIconsConstants.Icons.Image3)]
    public class ImageMediaModel : ImageData
    {
        //// Content tab

        [CultureSpecific]
        [Display(
            GroupName = SystemTabNames.Content,
            Order = 10)]
        public virtual string Heading { get; set; }

        [CultureSpecific]
        [Display(
            GroupName = SystemTabNames.Content,
            Order = 20)]
        [UIHint(UIHint.Textarea)]
        public virtual string MainIntro { get; set; }

        [CultureSpecific]
        [Display(
            GroupName = SystemTabNames.Content,
            Order = 30)]
        public virtual string Title { get; set; }

        [CultureSpecific]
        [Display(
            GroupName = SystemTabNames.Content,
            Order = 40)]
        public virtual string Alt { get; set; }

        [CultureSpecific]
        [Display(
            GroupName = SystemTabNames.Content,
            Order = 50)]
        public virtual string Copyright { get; set; }
    }
}