using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Shell.ObjectEditing;
using Knowit.EpiserverFramework.EpiCore.Features.ContentTypeThumbnail;
using Knowit.EpiserverFramework.EpiCore.Features.SelectionFactories;
using Knowit.EpiserverFramework.Models.Core;

namespace Knowit.EpiserverFramework.Models.Blocks
{
    /// <summary>
    /// Image slide link block model
    /// </summary>
    [ContentType(
        GUID = "7ad021b0-36da-47d7-8eec-c4fe4b18190e",
        GroupName = ModelsConstants.ContentTypeGroupNames.Block)]
    [ContentTypeThumbnail(ContentTypeThumbnailConstants.ContentTypeThumbnails.ImageSlideLinkBlock)]
    public class ImageSlideLinkBlockModel : SiteBlockData
    {
        //// Content tab

        [Display(
            GroupName = SystemTabNames.Content,
            Order = 70)]
        [AllowedTypes(typeof(ImageSlideBlockModel))]
        public virtual ContentArea ImageSlides { get; set; }

        [Display(
            GroupName = SystemTabNames.Content,
            Order = 80)]
        [SelectOne(SelectionFactoryType = typeof(SlideIntervalSelectionFactory))]
        public virtual string SlideInterval { get; set; }

        //// Default values

        public override void SetDefaultValues(ContentType contentType)
        {
            base.SetDefaultValues(contentType);

            SlideInterval = "5000";
        }
    }
}