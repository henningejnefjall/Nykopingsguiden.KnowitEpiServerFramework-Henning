using System.Web.Mvc;
using EPiServer.Web.Mvc;
using Knowit.EpiserverFramework.Models.Blocks;

namespace Knowit.EpiserverFramework.Web.Features.Blocks.MeetInNykgTipsContainerBlock
{
    /// <summary>
    /// Meet in Nykoping tips container block controller
    /// </summary>
    public class MeetInNykgTipsContainerBlockController : BlockController<MeetInNykgTipsContainerBlockModel>
    {
        public ActionResult Index(MeetInNykgTipsContainerBlockModel currentBlock)
        {
            var model = new MeetInNykgTipsContainerBlockViewModel(currentBlock);

            return PartialView(model);
        }
    }
}