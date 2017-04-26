using System.ServiceModel.Syndication;
using Knowit.EpiserverFramework.Models.Blocks;

namespace Knowit.EpiserverFramework.Web.Features.Blocks.RssReaderBlock
{
    /// <summary>
    /// RSS reader block view model
    /// </summary>
    public sealed class RssReaderBlockViewModel
    {
        public RssReaderBlockViewModel(RssReaderBlockModel rssReaderBlock)
        {
            RssReaderBlock = rssReaderBlock;
        }

        public RssReaderBlockModel RssReaderBlock
        {
            get; set;
        }

        public SyndicationFeed RssFeed
        {
            get; set;
        }
    }
}