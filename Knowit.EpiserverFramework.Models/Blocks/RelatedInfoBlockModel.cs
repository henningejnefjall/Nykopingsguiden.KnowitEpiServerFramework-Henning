using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Shell.ObjectEditing;
using Knowit.EpiserverFramework.EpiCore.Features.ContentTypeThumbnail;
using Knowit.EpiserverFramework.EpiCore.Features.EnumEditorDescriptor;
using Knowit.EpiserverFramework.Models.Core;

namespace Knowit.EpiserverFramework.Models.Blocks
{
    /// <summary>
    /// Related info block model
    /// </summary>
    [ContentType(
        GUID = "49446f28-e3b5-4c2f-8c78-d7f842c8c201",
        GroupName = ModelsConstants.ContentTypeGroupNames.Block)]
    [ContentTypeThumbnail(ContentTypeThumbnailConstants.ContentTypeThumbnails.RelatedInfoBlock)]
    public class RelatedInfoBlockModel : SiteBlockData
    {
        public enum PagetypeChoice
        {
            BesoksmalOchVerkamheter = 0,
            Evenemang = 1
        }

        //// Content tab

        [BackingType(typeof(PropertyNumber))]
        [EditorDescriptor(EditorDescriptorType = typeof(EnumEditorDescriptor<PagetypeChoice>))]
        public virtual PagetypeChoice ListPageType { get; set; }

        [Display(
            GroupName = SystemTabNames.Content,
            Order = 20)]
        [CultureSpecific]
        public virtual string Title { get; set; }

        [Display(
            GroupName = SystemTabNames.Content,
            Order = 80)]
        public virtual int MaxItems { get; set; }
    }
}