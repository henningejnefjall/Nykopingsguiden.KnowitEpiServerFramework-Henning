using System.ComponentModel.DataAnnotations;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web;
using Knowit.EpiserverFramework.EpiCore.Features.ContentTypeThumbnail;
using Knowit.EpiserverFramework.EpiCore.Features.PageTreeIcons;
using Knowit.EpiserverFramework.Models.Core;

namespace Knowit.EpiserverFramework.Models.Media
{
    /// <summary>
    /// Excel file media model
    /// </summary>
    [ContentType( 
        GUID = "0d1a0671-3514-41f4-b2e0-0c12ed9557c0")]
    [MediaDescriptor(ExtensionString = "xls, xlsx")]
    [ContentTypeThumbnail(PageTreeIconsConstants.Icons.FileSpreadsheet2)]
    public class ExcelMediaModel : SiteMediaData
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