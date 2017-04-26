using Knowit.EpiserverFramework.Models.Blocks;

namespace Knowit.EpiserverFramework.Web.Features.Blocks.PagesBlock
{
    /// <summary>
    /// Pages block view model
    /// </summary>
    public sealed class PagesBlockViewModel
    {
        public PagesBlockViewModel(PagesBlockModel pagesBlock)
        {
            PagesBlock = pagesBlock;
        }

        public PagesBlockModel PagesBlock { get; private set; }
    }
}