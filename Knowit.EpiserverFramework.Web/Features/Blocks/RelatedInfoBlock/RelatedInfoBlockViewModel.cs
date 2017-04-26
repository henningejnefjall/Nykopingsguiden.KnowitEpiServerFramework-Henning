using System.Collections.Generic;
using EPiServer.Core;
using Knowit.EpiserverFramework.Models.Blocks;

namespace Knowit.EpiserverFramework.Web.Features.Blocks.RelatedInfoBlock
{
    /// <summary>
    /// Related info block view model
    /// </summary>
    public sealed class RelatedInfoBlockViewModel
    {
        public RelatedInfoBlockViewModel(RelatedInfoBlockModel relatedInfoBlock)
        {
            RelatedInfoBlock = relatedInfoBlock;
        }

        public RelatedInfoBlockModel RelatedInfoBlock { get; private set; }

        public IEnumerable<PageData> CategoryPages { get; set; } 
    }
}