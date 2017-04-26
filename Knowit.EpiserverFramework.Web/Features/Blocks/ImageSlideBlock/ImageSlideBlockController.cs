using System.Web.Mvc;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using EPiServer.Web.WebControls;
using Knowit.EpiserverFramework.Models.Blocks;

namespace Knowit.EpiserverFramework.Web.Features.Blocks.ImageSlideBlock
{
    /// <summary>
    /// Image slide block controller
    /// </summary>
    [TemplateDescriptor(Default = true)]
    public class ImageSlideBlockController : BlockController<ImageSlideBlockModel>
    {
        public override ActionResult Index(ImageSlideBlockModel currentBlock)
        {
            ViewData.Add(RenderSettings.HasContainerElement, false);

            var model = new ImageSlideBlockViewModel(currentBlock);

            return PartialView(model);
        }
    }
}
