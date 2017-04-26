using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using Knowit.EpiserverFramework.Models.Core;

namespace Knowit.EpiserverFramework.Models.Blocks
{
    /// <summary>
    /// Pages block model
    /// </summary>
    [ContentType(
        GUID = "49e36f28-e3b5-4c2d-8c78-d7f8216fc208",
        GroupName = ModelsConstants.ContentTypeGroupNames.Block)]
    public class PagesBlockModel : SiteBlockData
    {
        //// Content tab

        [Display(
            GroupName = SystemTabNames.Content,
            Order = 20)]
        [CultureSpecific]
        public virtual string Title { get; set; }

        [Display(
            GroupName = SystemTabNames.Content,
            Order = 25)]
        [CultureSpecific]
        public virtual XhtmlString Extract { get; set; }

        [Display(
            GroupName = SystemTabNames.Content,
            Order = 30)]
        public virtual PageReference Link { get; set; }
    }
}