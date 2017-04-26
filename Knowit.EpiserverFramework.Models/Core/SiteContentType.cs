using EPiServer.DataAnnotations;

namespace Knowit.EpiserverFramework.Models.Core
{
    /// <summary>
    /// Attribute used for site content types, default attribute values
    /// </summary>
    public class SiteContentType : ContentTypeAttribute
    {
        public SiteContentType()
        {
            GroupName = ModelsConstants.ContentTypeGroupNames.Default;
        }
    }
}
