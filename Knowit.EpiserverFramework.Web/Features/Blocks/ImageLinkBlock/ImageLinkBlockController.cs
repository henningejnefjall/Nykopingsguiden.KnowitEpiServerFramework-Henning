using System.Web.Mvc;
using EPiServer.Web.Mvc;
using Knowit.EpiserverFramework.Models.Blocks;

namespace Knowit.EpiserverFramework.Web.Features.Blocks.ImageLinkBlock
{
    /// <summary>
    /// Image link block controller
    /// </summary>
    public class ImageLinkBlockController : BlockController<ImageLinkBlockModel>
    {
        public override ActionResult Index(ImageLinkBlockModel currentBlock)
        {
            return PartialView(new ImageLinkBlockViewModel(currentBlock));
        }
    }
}
