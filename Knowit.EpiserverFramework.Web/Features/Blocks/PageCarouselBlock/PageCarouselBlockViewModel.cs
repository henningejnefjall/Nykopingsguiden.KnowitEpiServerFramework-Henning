using Knowit.EpiserverFramework.Models.Blocks;

namespace Knowit.EpiserverFramework.Web.Features.Blocks.PageCarouselBlock
{
    /// <summary>
    /// Page carousel block view model
    /// </summary>
    public sealed class PageCarouselBlockViewModel
    {
        public PageCarouselBlockViewModel(PageCarouselBlockModel pageCarouselBlock)
        {
            Name = pageCarouselBlock.Property.Keys.ToString();
            PageCarouselBlock = pageCarouselBlock;
        }

        public PageCarouselBlockModel PageCarouselBlock { get; private set; }

        public string Name { get; private set; }
    }
}