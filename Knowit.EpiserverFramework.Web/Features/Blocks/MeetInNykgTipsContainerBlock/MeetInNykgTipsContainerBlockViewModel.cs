using Knowit.EpiserverFramework.Models.Blocks;

namespace Knowit.EpiserverFramework.Web.Features.Blocks.MeetInNykgTipsContainerBlock
{
    /// <summary>
    /// Meet in Nykoping tips container block view model
    /// </summary>
    public class MeetInNykgTipsContainerBlockViewModel
    {
        public MeetInNykgTipsContainerBlockViewModel(MeetInNykgTipsContainerBlockModel meetInNykgTipsContainerBlock)
        {
            MeetInNykgTipsContainerBlock = meetInNykgTipsContainerBlock;
        }

        public MeetInNykgTipsContainerBlockModel MeetInNykgTipsContainerBlock { get; private set; }
    }
}