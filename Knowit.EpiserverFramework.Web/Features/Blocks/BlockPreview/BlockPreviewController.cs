using System.Linq;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Framework.Web;
using EPiServer.Web;
using Knowit.EpiserverFramework.Models.Core;
using Knowit.EpiserverFramework.Models.ViewModels;

namespace Knowit.EpiserverFramework.Web.Features.Blocks.BlockPreview
{
    /* Note: as the content area rendering on the site is customized we create ContentArea instances 
     * which we render in the preview view in order to provide editors with a preview which is as 
     * realistic as possible. In other contexts we could simply have passed the block to the 
     * view and rendered it using Html.RenderContentData */
    [TemplateDescriptor(
        Inherited = true,
        // Required as controllers for blocks are registered as MvcPartialController by default
        TemplateTypeCategory = TemplateTypeCategories.MvcController,
        Tags = new[] { RenderingTags.Preview, RenderingTags.Edit },
        AvailableWithoutTag = false)]
    public class BlockPreviewController : Controller, IRenderTemplate<BlockData>, IModifyLayout
    {
        private readonly IContentLoader contentLoader;
        private readonly TemplateResolver templateResolver;
        private readonly DisplayOptions displayOptions;
        
        // public BlockPreviewController(){
        //    contentLoader = ServiceLocator.Current.GetInstance<IContentLoader>(); 
        // }
        public BlockPreviewController(IContentLoader contentLoaderInput, TemplateResolver templateResolverInput, DisplayOptions displayOptionsInput)
        {
            contentLoader = contentLoaderInput;
            templateResolver = templateResolverInput;
            displayOptions = displayOptionsInput;
        }

        public void ModifyLayout(LayoutModel layoutModel)
        {
            layoutModel.HideHeader = true;
            layoutModel.HideFooter = true;
        }

        public ActionResult Index(IContent currentContent)
        {
            // As the layout requires a page for title etc we "borrow" the start page
            var startPage = contentLoader.Get<SitePageData>(ContentReference.StartPage);
            var model = new BlockPreviewViewModel(startPage, currentContent);
            var supportedDisplayOptions = displayOptions?.OrderByDescending(x => int.Parse(x.Description)).Select(x => new { Tag = x.Tag, Name = x.Name, Supported = SupportsTag(currentContent, x.Tag) }).ToList();

            if (/*supportedDisplayOptions == null ||*/ !supportedDisplayOptions.Any(x => x.Supported))
            {
                return View(model);
            }

            foreach (var displayOption in supportedDisplayOptions)
            {
                var contentArea = new ContentArea();
                contentArea.Items.Add(new ContentAreaItem
                {
                    ContentLink = currentContent.ContentLink
                });

                var areaModel = new BlockPreviewViewModel.PreviewArea
                {
                    Supported = displayOption.Supported,
                    AreaTag = displayOption.Tag,
                    AreaName = displayOption.Name,
                    ContentArea = contentArea
                };

                model.Areas.Add(areaModel);
            }

            return View(model);
        }

        private bool SupportsTag(IContent content, string tag)
        {
            var templateModel = templateResolver.Resolve(
                HttpContext,
                content.GetOriginalType(),
                content,
                TemplateTypeCategories.MvcPartial,
                tag);

            return templateModel != null;
        }
    }
}