using System.ComponentModel.DataAnnotations;
using EPiServer;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using Knowit.EpiserverFramework.Models.Core;

namespace Knowit.EpiserverFramework.Models.LocalBlocks
{
    /// <summary>
    /// Local link block model
    /// Text, title, url and open in new window
    /// </summary>
    [ContentType(
        GUID = "c8d08f89-9702-4024-9a74-00b9a62b6a6a",
        GroupName = ModelsConstants.ContentTypeGroupNames.LocalBlock,
        AvailableInEditMode = false)]
    public class LinkBlockModel : SiteLocalBlockData
    {
        //// Content tab

        [Display(
            GroupName = SystemTabNames.Content,
            Order = 10)]
        [CultureSpecific]
        public virtual string LinkText { get; set; }

        [Display(
            GroupName = SystemTabNames.Content,
            Order = 30)]
        [CultureSpecific]
        public virtual string LinkTitle { get; set; }

        [Display(
            GroupName = SystemTabNames.Content,
            Order = 20)]
        [CultureSpecific]
        public virtual Url LinkUrl { get; set; }

        [Display(
            GroupName = SystemTabNames.Content,
            Order = 50)]
        [CultureSpecific]
        public virtual bool NewWindow { get; set; }
    }
}