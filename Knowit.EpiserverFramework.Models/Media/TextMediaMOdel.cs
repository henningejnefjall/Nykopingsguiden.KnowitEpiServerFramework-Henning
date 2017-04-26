using EPiServer.DataAnnotations;
using EPiServer.Framework.DataAnnotations;
using Knowit.EpiserverFramework.Models.Core;

namespace Knowit.EpiserverFramework.Models.Media
{
    /// <summary>
    /// Text file media model
    /// </summary>
    [ContentType(GUID = "10b33692-ea43-4a69-8648-27000eb7357e")]
    [MediaDescriptor(ExtensionString = "txt")]
    public class TextMediaModel : SiteMediaData
    {
        //// Content tab
    }
}