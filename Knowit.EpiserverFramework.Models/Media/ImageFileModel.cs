using System.ComponentModel.DataAnnotations;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Web;
using Knowit.EpiserverFramework.Models.Core;

namespace Knowit.EpiserverFramework.Models.Media
{
    [ContentType(DisplayName = "ImageFile", GUID = "7a7122ba-f108-49bd-8dc7-cc5a8803ea83", Description = "")]
    /*[MediaDescriptor(ExtensionString = "pdf,doc,docx")]*/
    public class ImageFile : DefaultMediaModel
    {
        [CultureSpecific]
        [Editable(true)]
        [Display(
            Name = "Alternate text",
            Description = "Description of the image",
            GroupName = SystemTabNames.Content,
            Order = 1)]
        public virtual string Description { get; set; }
    }
}