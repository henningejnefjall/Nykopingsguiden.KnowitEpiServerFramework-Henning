using System;
using System.ComponentModel.DataAnnotations;
using EPiServer;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using Knowit.EpiserverFramework.EpiCore.Features.ContentTypeThumbnail;
using Knowit.EpiserverFramework.Models.Core;
using Knowit.EpiserverFramework.Models.LocalBlocks;

namespace Knowit.EpiserverFramework.Models.Blocks
{
    /// <summary>
    /// Imagelink block model
    /// </summary>
    [ContentType(GUID = "3568a68d-a28a-46e3-b9cd-d588106434ab", 
    GroupName = ModelsConstants.ContentTypeGroupNames.Block)]
    [ContentTypeThumbnail(ContentTypeThumbnailConstants.ContentTypeThumbnails.ImageLinkBlock)]
    public class ImageLinkBlockModel : SiteBlockData
    {
        [Display(
            GroupName = SystemTabNames.Content,
            Order = 10)]
        public virtual ImageBlockModel Image { get; set; }

        [Display(
            GroupName = SystemTabNames.Content,
            Order = 20)]
        public virtual Url LinkUrl { get; set; }

        [Display(
    GroupName = SystemTabNames.Content,
    Order = 20)]
        public virtual string LinkTitle { get; set; }
    }
}