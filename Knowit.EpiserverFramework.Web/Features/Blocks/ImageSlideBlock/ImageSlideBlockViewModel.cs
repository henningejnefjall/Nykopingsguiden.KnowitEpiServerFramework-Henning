using Knowit.EpiserverFramework.Models.Blocks;

namespace Knowit.EpiserverFramework.Web.Features.Blocks.ImageSlideBlock
{
    /// <summary>
    /// Images slide block view model
    /// </summary>
    public sealed class ImageSlideBlockViewModel
    {
        public ImageSlideBlockViewModel(ImageSlideBlockModel imageSlideBlock)
        {
            ImageSlideBlock = imageSlideBlock;
        }

        public ImageSlideBlockModel ImageSlideBlock { get; private set; }
    }
}