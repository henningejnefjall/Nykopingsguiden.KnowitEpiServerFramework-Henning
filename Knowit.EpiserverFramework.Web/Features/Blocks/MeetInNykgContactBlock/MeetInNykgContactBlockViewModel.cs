using Knowit.EpiserverFramework.Models.Blocks;

namespace Knowit.EpiserverFramework.Web.Features.Blocks.MeetInNykgContactBlock
{
    /// <summary>
    /// Meet in Nykoping contact block view model
    /// </summary>
    public sealed class MeetInNykgContactBlockViewModel
    {
        public MeetInNykgContactBlockViewModel(MeetInNykgContactBlockModel meetInNykgContactBlock)
        {
            MeetInNykgContactBlock = meetInNykgContactBlock;
        }

        public MeetInNykgContactBlockModel MeetInNykgContactBlock { get; private set; }
    }
}