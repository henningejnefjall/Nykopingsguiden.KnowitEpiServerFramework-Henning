using EPiServer.DataAnnotations;

namespace Knowit.EpiserverFramework.EpiCore.Features.ContentTypeThumbnail
{
    /// <summary>
    /// Attribute to set the default thumbnail for site page and block types
    /// </summary>
    public class ContentTypeThumbnail : ImageUrlAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ContentTypeThumbnail"/> class. 
        /// The constructor will initialize a SiteImageUrl attribute with a default thumbnail
        /// </summary>
        public ContentTypeThumbnail() : base(ContentTypeThumbnailConstants.ContentTypeThumbnails.Default)
        {
        }

        public ContentTypeThumbnail(string path) : base(path)
        {
        }
    }
}
