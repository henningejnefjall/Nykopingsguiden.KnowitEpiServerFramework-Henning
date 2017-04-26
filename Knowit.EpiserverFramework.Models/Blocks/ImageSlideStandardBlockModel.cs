using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Shell.ObjectEditing;
using EPiServer.Web;
using Knowit.EpiserverFramework.EpiCore.Features.ContentTypeThumbnail;
using Knowit.EpiserverFramework.EpiCore.Features.SelectionFactories;
using Knowit.EpiserverFramework.Models.Core;
using Knowit.EpiserverFramework.Models.Media;

namespace Knowit.EpiserverFramework.Models.Blocks
{
    /// <summary>
    /// Image slide standard block model
    /// </summary>
    [ContentType(
        GUID = "816c2a1b-e51e-420a-acce-b4e23339c3ce",
        GroupName = ModelsConstants.ContentTypeGroupNames.Block)]
    [ContentTypeThumbnail(ContentTypeThumbnailConstants.ContentTypeThumbnails.ImageSlideLinkBlock)]

    public class ImageSlideStandardBlockModel : SiteBlockData
    {
        //// Content tab

        [Display(
           GroupName = SystemTabNames.Content,
           Order = 20)]
        [CultureSpecific]
        [UIHint(UIHint.Textarea)]
        public virtual string MainIntro { get; set; }

        [Display(
            GroupName = SystemTabNames.Content,
           Order = 30)]
        [AllowedTypes(typeof(ImageMediaModel))]
        public virtual ContentArea ImageSlides { get; set; }

        [Display(
            GroupName = SystemTabNames.Content,
           Order = 40)]
        [SelectOne(SelectionFactoryType = typeof(SlideIntervalSelectionFactory))]
        public virtual string SlideInterval { get; set; }

        [Display(
            GroupName = SystemTabNames.Content,
           Order = 50)]
        [SelectOne(SelectionFactoryType = typeof(TextPositionSelectionFactory))]
        public virtual string Position { get; set; }

        //// Default values

        public override void SetDefaultValues(ContentType contentType)
        {
            base.SetDefaultValues(contentType);

            SlideInterval = "5000";
            Position = "center";
        }
    }
}