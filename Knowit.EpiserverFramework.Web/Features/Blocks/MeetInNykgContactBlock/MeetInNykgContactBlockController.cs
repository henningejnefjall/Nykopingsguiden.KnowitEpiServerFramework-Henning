using System.Web.Mvc;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using Knowit.EpiserverFramework.Models.Blocks;

namespace Knowit.EpiserverFramework.Web.Features.Blocks.MeetInNykgContactBlock
{
    /// <summary>
    /// Meet in Nykoping contact block controller
    /// </summary>
    [TemplateDescriptor(Default = true)]
    public class MeetInNykgContactBlockController : BlockController<MeetInNykgContactBlockModel>
    {
        public override ActionResult Index(MeetInNykgContactBlockModel currentBlock)
        {
            var model = new MeetInNykgContactBlockViewModel(currentBlock);

            return PartialView(model);
        }
    }
}
