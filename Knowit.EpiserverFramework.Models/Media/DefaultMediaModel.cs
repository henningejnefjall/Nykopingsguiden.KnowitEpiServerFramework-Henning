using System.ComponentModel.DataAnnotations;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Web;
using Knowit.EpiserverFramework.Models.Core;

namespace Knowit.EpiserverFramework.Models.Media
{
    /// <summary>
    /// Default media model
    /// </summary>
    [ContentType(
        GUID = "36d00057-ba97-428a-89d1-fed96dfb1549")]
    public class DefaultMediaModel : SiteMediaData
    {
        //// Content tab

        [CultureSpecific]
        [Display(
           GroupName = SystemTabNames.Content,
           Order = 20)]
        [UIHint(UIHint.Textarea)]
        public virtual string MainIntro { get; set; }
    }
}