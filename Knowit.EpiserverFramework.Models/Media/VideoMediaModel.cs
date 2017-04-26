using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web;

namespace Knowit.EpiserverFramework.Models.Media
{
    /// <summary>
    /// Video file media model
    /// </summary>
    [ContentType(
        GUID = "2db49a90-6596-4aa5-bfdc-fbb22ff2bb75")]
    [MediaDescriptor(ExtensionString = "flv,mp4,webm")]
    public class VideoMediaModel : VideoData
    {
        //// Content tab

        [CultureSpecific]
        [Display(
           GroupName = SystemTabNames.Content,
           Order = 10)]
        [UIHint(UIHint.Image)]
        public virtual ContentReference PreviewImage { get; set; }

        [CultureSpecific]
        [Display(
            GroupName = SystemTabNames.Content,
            Order = 20)]
        public virtual string Heading { get; set; }

        [CultureSpecific]
        [UIHint(UIHint.Textarea)]
        [Display(
            GroupName = SystemTabNames.Content,
            Order = 30)]
        public virtual string MainIntro { get; set; }

        [CultureSpecific]
        [Display(
            GroupName = SystemTabNames.Content,
            Order = 40)]
        public virtual string Copyright { get; set; }
    }
}