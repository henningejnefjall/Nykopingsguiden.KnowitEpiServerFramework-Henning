using Knowit.EpiserverFramework.Models.Blocks;

namespace Knowit.EpiserverFramework.Web.Features.Blocks.ImageSlideLinkBlock
{
    /// <summary>
    /// General block view model
    /// </summary>
    public sealed class ImageSlideLinkBlockViewModel
    {
        public ImageSlideLinkBlockViewModel(ImageSlideLinkBlockModel imageSlideLinkBlock)
        {
            ImageSlideLinkBlock = imageSlideLinkBlock;
        }

        public ImageSlideLinkBlockModel ImageSlideLinkBlock { get; private set; }
    }
}