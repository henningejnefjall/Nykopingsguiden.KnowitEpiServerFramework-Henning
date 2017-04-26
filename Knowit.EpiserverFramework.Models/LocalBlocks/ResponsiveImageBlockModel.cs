using System;
using System.ComponentModel.DataAnnotations;
using EPiServer;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Web;
using Knowit.EpiserverFramework.Models.Core;

namespace Knowit.EpiserverFramework.Models.LocalBlocks
{
    /// <summary>
    /// Responsive image block. Image, mobileimage, alt and title. 
    /// </summary>
    [SiteContentType(
        GUID = "392cf534-420e-4290-9c31-03b4358d96ec",
        GroupName = ModelsConstants.ContentTypeGroupNames.LocalBlock,
        AvailableInEditMode = false)]
    public class ResponsiveImageBlockModel : ImageBlockModel
    {
        //[Display(
        //    GroupName = SystemTabNames.Content,
        //    Order = 20)]
        //[UIHint(UIHint.Image)]
        //public virtual ContentReference MobileImage { get; set; }
    }
}