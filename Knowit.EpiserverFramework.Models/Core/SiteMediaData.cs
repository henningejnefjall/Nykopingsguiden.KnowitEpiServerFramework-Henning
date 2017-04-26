using System.ComponentModel.DataAnnotations;
using EPiServer;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;

namespace Knowit.EpiserverFramework.Models.Core
{
    /// <summary>
    /// Base class for media
    /// </summary>
    public class SiteMediaData : MediaData
    {
        [Display(
            GroupName = SystemTabNames.Content,
            Order = 10)]
        [CultureSpecific]
        public virtual string Heading { get; set; }

        [Display(
            GroupName = SystemTabNames.Content,
            Order = 20)]
        [CultureSpecific]
        public virtual string Description { get; set; }

        [Display(
            GroupName = SystemTabNames.Content,
            Order = 30)]
        [CultureSpecific]
        public virtual Url Image { get; set; }

        [Display(
            GroupName = SystemTabNames.Content,
            Order = 40)]
        [CultureSpecific]
        public virtual string Publisher { get; set; }

        [Display(
            GroupName = SystemTabNames.Content,
            Order = 50)]
        [CultureSpecific]
        public virtual string Copyright { get; set; }
    }
}