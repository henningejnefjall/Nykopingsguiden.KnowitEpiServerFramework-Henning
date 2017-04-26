using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAnnotations;
using EPiServer.Web;
using Knowit.EpiserverFramework.Models.Core;

namespace Knowit.EpiserverFramework.Models.LocalBlocks
{
    /// <summary>
    /// Search engine optimization block model
    /// Properties used on the SEO tab on all page types
    /// Metatitle, Metadescription, Metakeywords, Metaauthor, Metacopyright, NoIndex, Nofollow
    /// </summary>
    [SiteContentType(
        GUID = "707db747-71d5-47d9-bddd-0fdf01fd3691",
        GroupName = ModelsConstants.ContentTypeGroupNames.LocalBlock,
        AvailableInEditMode = false)]
    public class SearchEngineOptimizationBlockModel : SiteLocalBlockData
    {
        //// SEO tab

        [Display(
            GroupName = SiteGroupDefinitions.Seo,
            Order = 10)]
        [CultureSpecific]
        public virtual string MetaTitle
        {
            get
            {    
                return this.GetPropertyValue(p => p.MetaTitle);
            }

            set
            {
                this.SetPropertyValue(p => p.MetaTitle, value);
            }
        }

        [Display(
            GroupName = SiteGroupDefinitions.Seo,
            Order = 20)]
        [CultureSpecific]
        [UIHint(UIHint.Textarea)]
        public virtual string MetaDescription { get; set; }

        [Display(
            GroupName = SiteGroupDefinitions.Seo,
            Order = 30)]
        [CultureSpecific]
        public virtual string MetaKeywords { get; set; }

        [Display(
            GroupName = SiteGroupDefinitions.Seo,
            Order = 40)]
        [Searchable(false)]
        public virtual string MetaAuthor { get; set; }

        [Display(
            GroupName = SiteGroupDefinitions.Seo,
            Order = 50)]
        [Searchable(false)]
        [CultureSpecific]
        public virtual string MetaCopyright { get; set; }

        [Display(
            GroupName = SiteGroupDefinitions.Seo,
            Order = 60)]
        public virtual bool NoIndex { get; set; }

        [Display(
            GroupName = SiteGroupDefinitions.Seo,
            Order = 70)]
        public virtual bool NoFollow { get; set; }
    }
}
