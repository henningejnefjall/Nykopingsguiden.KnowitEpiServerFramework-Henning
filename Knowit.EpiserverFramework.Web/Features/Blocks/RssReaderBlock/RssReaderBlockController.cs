using System;
using System.Linq;
using System.Net;
using System.ServiceModel.Syndication;
using System.Web.Mvc;
using System.Xml;
using EPiServer.Web.Mvc;
using Knowit.EpiserverFramework.Models.Blocks;

namespace Knowit.EpiserverFramework.Web.Features.Blocks.RssReaderBlock
{
    /// <summary>
    /// RSS reader block controller
    /// </summary>
    public class RssReaderBlockController : BlockController<RssReaderBlockModel>
    {
        public override ActionResult Index(RssReaderBlockModel currentBlock)
        {
            var model = new RssReaderBlockViewModel(currentBlock)
            {
                RssReaderBlock = currentBlock
            };

            if ((currentBlock.RssUrl == null) || currentBlock.RssUrl.IsEmpty())
            {
                return PartialView(model);
            }

            try
            {
                var feed = new SyndicationFeed();

                var request = WebRequest.Create(Convert.ToString(currentBlock.RssUrl));

                request.Timeout = 3000;

                var requestAnswer = request.GetResponse().GetResponseStream();

                XmlReader xmlReader = null;

                if (requestAnswer != null)
                {
                    xmlReader = XmlReader.Create(requestAnswer);
                }

                if (xmlReader != null)
                {
                    feed = SyndicationFeed.Load(xmlReader);
                }

                if (feed != null)
                {
                    feed.Items = feed.Items.Take(model.RssReaderBlock.MaxNumberOfItems);

                    model.RssFeed = feed;
                }
            }
            catch (Exception ex)
            {
                // if (Logger.IsErrorEnabled)
                // {
                //    Logger.Error("Rss reader error: " + ex);
                // }
            }

            return PartialView(model);
        }
    }
}
