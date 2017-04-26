namespace Knowit.EpiserverFramework.Web.Helpers
{
    using System.Web.Mvc;
    using EPiServer;
    using EPiServer.Core;
    using EPiServer.ServiceLocation;
    using EPiServer.Web.Routing;
    using Models.Media;

    /// <summary>
    /// Media helper
    /// </summary>
    public static class MediaHelper
    {
        /// <summary>
        /// Render image tag
        /// </summary>
        /// <param name="helper">HtmlHelper</param>
        /// <param name="imageFile">ContentReference</param>
        /// <param name="alt">Alternative text</param>
        /// <param name="title">Title text</param>
        /// <param name="cssClass">css class added to image tag</param>
        /// <param name="imageOptions">optional image options, defined in ImageMedia</param>
        /// <returns>String</returns>
        public static string RenderImageTag(this HtmlHelper helper, ContentReference imageFile, string alt = null, string title = null, string cssClass = null, string imageOptions = null)
        {
            var currentContent = !ContentReference.IsNullOrEmpty(imageFile) ? ServiceLocator.Current.GetInstance<IContentLoader>().Get<MediaData>(imageFile) : null;

            var file = currentContent as ImageMediaModel;

            if (file == null)
            {
                return string.Empty;
            }

            var imageOptionsUrl = string.Empty;

            if (imageOptions != null)
            {
                imageOptionsUrl = $"/{imageOptions}";
            }

            var internalUrl = UrlResolver.Current.GetUrl(file.ContentLink);

            var url = new UrlBuilder(internalUrl);

            Global.UrlRewriteProvider.ConvertToExternal(url, null, System.Text.Encoding.UTF8);

            var friendlyUrl = UriSupport.AbsoluteUrlBySettings(url.ToString());

            return $"<img src='{friendlyUrl}{imageOptionsUrl}' alt='{alt ?? file.Alt}' title='{title ?? file.Title}' class='{cssClass}'/>";
        }

        /// <summary>
        /// Render source tag to picture element
        /// </summary>
        /// <param name="helper">HtmlHelper</param>
        /// <param name="image">Contentreference</param>
        /// <param name="media">Media query text</param>
        /// <returns>Source tag string</returns>
        public static string RenderPictureSourceTag(this HtmlHelper helper, ContentReference image, string media = null)
        {
            return image == null ? string.Empty : $"<source srcset='{UrlResolver.Current.GetUrl(image)}' media='({media})'>";
        }

        public static string RenderVideoTag(this HtmlHelper helper, ContentReference videoFile, string alt = null, string title = null, string cssClass = null, string videoOptions = null)
        {
            var currentContent = !ContentReference.IsNullOrEmpty(videoFile) ? ServiceLocator.Current.GetInstance<IContentLoader>().Get<VideoData>(videoFile) : null;

            var file = currentContent as VideoMediaModel;

            if (file == null)
            {
                return string.Empty;
            }

            var videoOptionsUrl = string.Empty;

            if (videoOptions != null)
            {
                videoOptionsUrl = $"/{videoOptions}";
            }

            var internalUrl = UrlResolver.Current.GetUrl(file.ContentLink);

            var url = new UrlBuilder(internalUrl);

            Global.UrlRewriteProvider.ConvertToExternal(url, null, System.Text.Encoding.UTF8);

            var friendlyUrl = UriSupport.AbsoluteUrlBySettings(url.ToString());

            return $"<video {videoOptionsUrl} class='{cssClass}'><source src='{friendlyUrl}' type='video/mp4'>{alt}</video>";

            ////return $"<img src='{friendlyUrl}{videoOptionsUrl}' alt='{alt ?? file.Alt}' title='{title ?? file.Title}' class='{cssClass}'/>";
        }
    }
}