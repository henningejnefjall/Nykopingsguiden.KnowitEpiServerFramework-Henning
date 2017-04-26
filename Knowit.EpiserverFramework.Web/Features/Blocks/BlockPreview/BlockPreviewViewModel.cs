using System.Collections.Generic;
using EPiServer.Core;
using Knowit.EpiserverFramework.Models.Core;
using Knowit.EpiserverFramework.Models.ViewModels;

namespace Knowit.EpiserverFramework.Web.Features.Blocks.BlockPreview
{
    public class BlockPreviewViewModel : PageViewModel<SitePageData>
    {
        public BlockPreviewViewModel(SitePageData currentPage, IContent previewContent) : base(currentPage)
        {
            PreviewContent = previewContent;
            Areas = new List<PreviewArea>();
        }

        public IContent PreviewContent { get; set; }

        public List<PreviewArea> Areas { get; set; }

        /// <summary>
        /// Preview area
        /// </summary>
        public class PreviewArea
        {
            public bool Supported { get; set; }

            public string AreaName { get; set; }

            public string AreaTag { get; set; }

            public ContentArea ContentArea { get; set; }
        }
    }
}