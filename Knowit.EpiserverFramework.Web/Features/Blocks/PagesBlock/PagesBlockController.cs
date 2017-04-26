using System.Web.Mvc;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using EPiServer.Web.WebControls;
using Knowit.EpiserverFramework.Models.Blocks;

namespace Knowit.EpiserverFramework.Web.Features.Blocks.PagesBlock
{
    /// <summary>
    /// General block controller
    /// </summary>
    [TemplateDescriptor(Default = true)]
    public class PagesBlockController : BlockController<PagesBlockModel>
    {
        public override ActionResult Index(PagesBlockModel currentBlock)
        {
            ViewData.Add(RenderSettings.HasContainerElement, false);

            var model = new PagesBlockViewModel(currentBlock);

            return PartialView(model);
        }
    }
}
