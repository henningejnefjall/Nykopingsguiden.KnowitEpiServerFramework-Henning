using System.Web.Mvc;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using EPiServer.Web.WebControls;
using Knowit.EpiserverFramework.Models.Blocks;

namespace Knowit.EpiserverFramework.Web.Features.Blocks.PageCarouselBlock
{
    /// <summary>
    /// Page carousel block controller
    /// </summary>
    [TemplateDescriptor(Default = true)]
    public class PageCarouselBlockController : BlockController<PageCarouselBlockModel>
    {
        public override ActionResult Index(PageCarouselBlockModel currentBlock)
        {
            ViewData.Add(RenderSettings.HasContainerElement, false);

            var model = new PageCarouselBlockViewModel(currentBlock);

            return PartialView(model);
        }
    }
}
