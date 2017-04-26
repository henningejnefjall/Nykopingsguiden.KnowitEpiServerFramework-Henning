using Knowit.EpiserverFramework.Models.Blocks;

namespace Knowit.EpiserverFramework.Web.Features.Blocks.ImageSlideStandardBlock
{
    /// <summary>
    /// Image slide standard block view model
    /// </summary>
    public sealed class ImageSlideStandardBlockViewModel
    {
        public ImageSlideStandardBlockViewModel(ImageSlideStandardBlockModel imageSlideStandardBlock)
        {
            ImageSlideStandardBlock = imageSlideStandardBlock;
        }

        public ImageSlideStandardBlockModel ImageSlideStandardBlock { get; private set; }
    }
}