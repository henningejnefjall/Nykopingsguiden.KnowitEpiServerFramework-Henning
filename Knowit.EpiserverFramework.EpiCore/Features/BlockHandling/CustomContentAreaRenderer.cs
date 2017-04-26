using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.Web;
using EPiServer.Web.Mvc.Html;

namespace Knowit.EpiserverFramework.EpiCore.Features.BlockHandling
{
    public class CustomContentAreaRenderer : ContentAreaRenderer
    {
        /// <summary>
        /// Get content area item css class
        /// </summary>
        /// <param name="htmlHelper">Html helper</param>
        /// <param name="contentAreaItem">Content area item</param>
        /// <returns>Tag</returns>
        protected override string GetContentAreaItemCssClass(HtmlHelper htmlHelper, ContentAreaItem contentAreaItem)
        {
            var itemCssClass = htmlHelper.ViewContext.ViewData["ItemCssClass"] as string;

            var tag = GetContentAreaItemTemplateTag(htmlHelper, contentAreaItem);

            return $"block {GetTypeSpecificCssClasses(contentAreaItem, ContentRepository)} {GetCssClassForTag(contentAreaItem.LoadDisplayOption())} {tag} {itemCssClass}";
        }

        /// <summary>
        /// Should render wrapping element
        /// </summary>
        /// <param name="htmlHelper">Html helper</param>
        /// <returns>Boolean</returns>
        protected override bool ShouldRenderWrappingElement(HtmlHelper htmlHelper)
        {
            bool renderContainer;

            if (htmlHelper.ViewContext.ViewData["RenderContainer"] != null &&
                bool.TryParse(htmlHelper.ViewContext.ViewData["RenderContainer"].ToString(), out renderContainer)
                && !renderContainer)
            {
                return false;
            }

            return base.ShouldRenderWrappingElement(htmlHelper);
        }

        /// <summary>
        /// Gets a CSS class used for styling based on a tag name (ie a Bootstrap class name)
        /// </summary>
        /// <param name="displayOption">The display Option</param>
        /// <returns>The <see cref="string"/></returns>
        private static string GetCssClassForTag(DisplayOption displayOption)
        {
            if (displayOption == null || string.IsNullOrEmpty(displayOption.Id))
            {
                return $"{EpiCoreConstants.ContentAreaIds.Full},{EpiCoreConstants.ContentAreaTags.FullWidth}";
            }

            return displayOption.Id;
        }

        /// <summary>
        /// Get type specific CSS class
        /// </summary>
        /// <param name="contentAreaItem">Content area item</param>
        /// <param name="contentRepository">content repository</param>
        /// <returns>Css class </returns>
        private static string GetTypeSpecificCssClasses(ContentAreaItem contentAreaItem, IContentRepository contentRepository)
        {
            var content = contentAreaItem.GetContent();
            var cssClass = content?.GetOriginalType().Name.ToLowerInvariant() ?? string.Empty;

            var customClassContent = content as ICustomCssInContentArea;
            if (customClassContent != null && !string.IsNullOrWhiteSpace(customClassContent.ContentAreaCssClass))
            {
                cssClass += $" {customClassContent.ContentAreaCssClass}";
            }

            return cssClass;
        }
    }
}
