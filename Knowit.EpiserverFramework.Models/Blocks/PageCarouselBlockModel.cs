using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using Knowit.EpiserverFramework.EpiCore.Features.ContentTypeThumbnail;
using Knowit.EpiserverFramework.Models.Core;

namespace Knowit.EpiserverFramework.Models.Blocks
{
    /// <summary>
    /// Page carousell block model
    /// </summary>
    [ContentType(
        GUID = "49ee5f28-e3b5-4c0d-8c78-d97821c8c208", 
        GroupName = ModelsConstants.ContentTypeGroupNames.Block)]
    [ContentTypeThumbnail(ContentTypeThumbnailConstants.ContentTypeThumbnails.ImageSlideLinkBlock)]
    public class PageCarouselBlockModel : SiteBlockData
    {
        //// Content tab

        [Display(
            GroupName = SystemTabNames.Content,
            Order = 70)]
        [AllowedTypes(typeof(PagesBlockModel))]
        public virtual ContentArea Pages { get; set; }
    }
}