using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;

namespace Knowit.EpiserverFramework.Models.Core
{
    /// <summary>
    /// Base class for blocks
    /// </summary>
    public abstract class SiteBlockData : BlockData
    {
        [Display(
            GroupName = SystemTabNames.PageHeader,
            Order = 1)]
        [CultureSpecific]
        public virtual string Heading
        {
            get
            {
                return !string.IsNullOrWhiteSpace(this.GetPropertyValue(block => block.Heading))
                    ? this.GetPropertyValue(block => block.Heading)
                    : this as IContent != null ? ((IContent)this).Name : string.Empty;
            }

            set
            {
                this.SetPropertyValue(page => page.Heading, value);
            }
        }
    }
}
