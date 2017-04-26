using System.Web.Mvc;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using EPiServer.Web.WebControls;
using Knowit.EpiserverFramework.Models.Blocks;

namespace Knowit.EpiserverFramework.Web.Features.Blocks.ImageSlideLinkBlock
{
    /// <summary>
    /// Image slide link block controller
    /// </summary>
    [TemplateDescriptor(Default = true)]
    public class ImageSlideLinkBlockController : BlockController<ImageSlideLinkBlockModel>
    {
        public override ActionResult Index(ImageSlideLinkBlockModel currentBlock)
        {
            var model = new ImageSlideLinkBlockViewModel(currentBlock);
            
            ViewData.Add(RenderSettings.HasContainerElement, false);

            return PartialView(model);
        }
    }
}
