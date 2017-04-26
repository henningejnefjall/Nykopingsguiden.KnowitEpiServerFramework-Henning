using Knowit.EpiserverFramework.Models.Blocks;

namespace Knowit.EpiserverFramework.Web.Features.Blocks.ImageLinkBlock
{
    /// <summary>
    /// Image link block view model
    /// </summary>
    public sealed class ImageLinkBlockViewModel
    {
        public ImageLinkBlockViewModel(ImageLinkBlockModel imageLinkBlock)
        {
            ImageLinkBlock = imageLinkBlock;
        }
        
        public ImageLinkBlockModel ImageLinkBlock { get; set; }
    }
}