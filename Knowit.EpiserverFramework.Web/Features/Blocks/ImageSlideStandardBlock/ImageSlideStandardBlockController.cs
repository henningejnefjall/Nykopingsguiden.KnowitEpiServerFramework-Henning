using System.Web.Mvc;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using EPiServer.Web.WebControls;
using Knowit.EpiserverFramework.Models.Blocks;

namespace Knowit.EpiserverFramework.Web.Features.Blocks.ImageSlideStandardBlock
{
    /// <summary>
    /// Image slide standard block controller
    /// </summary>
    [TemplateDescriptor(Default = true)]
    public class ImageSlideStandardBlockController : BlockController<ImageSlideStandardBlockModel>
    {
        public override ActionResult Index(ImageSlideStandardBlockModel currentBlock)
        {
            ViewData.Add(RenderSettings.HasContainerElement, false);

            var model = new ImageSlideStandardBlockViewModel(currentBlock);

            return PartialView(model);
        }
    }
}
