using System.ComponentModel.DataAnnotations;
using EPiServer;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using Knowit.EpiserverFramework.EpiCore.Features.ContentTypeThumbnail;
using Knowit.EpiserverFramework.Models.Core;

namespace Knowit.EpiserverFramework.Models.Blocks
{
    /// <summary>
    /// Rss reader block model
    /// </summary>
    [ContentType(
        GUID = "1b595b8c-e5b0-4638-8bd3-653621b1f9cf",
        GroupName = ModelsConstants.ContentTypeGroupNames.Block)]
    [ContentTypeThumbnail(ContentTypeThumbnailConstants.ContentTypeThumbnails.RssReaderBlock)]
    public class RssReaderBlockModel : SiteBlockData
    {
        //// Content tab

        [Display(
            GroupName = SystemTabNames.Content,
            Order = 10)]
        [CultureSpecific]
        public virtual XhtmlString MainIntro { get; set; }

        [Display(
           GroupName = SystemTabNames.Content,
           Order = 20)]
        [CultureSpecific]
        public virtual Url RssUrl { get; set; }

        [Display(
          GroupName = SystemTabNames.Content,
          Order = 30)]
        [CultureSpecific]
        public virtual int MaxNumberOfItems { get; set; }

        [Editable(true)]
        [Display(
            GroupName = SystemTabNames.Content,
            Order = 40)]
        public virtual bool IncludePublishDate { get; set; }

        [Editable(true)]
        [Display(
            GroupName = SystemTabNames.Content,
            Order = 50)]
        public virtual bool IncludeSummary { get; set; }

        [Editable(true)]
        [Display(
            GroupName = SystemTabNames.Content,
            Order = 60)]
        public virtual bool StripHtml { get; set; }

        //// Default values

        public override void SetDefaultValues(ContentType contentType)
        {
            base.SetDefaultValues(contentType);

            MaxNumberOfItems = 10;
            IncludePublishDate = false;
            IncludeSummary = false;
        }
    }
}