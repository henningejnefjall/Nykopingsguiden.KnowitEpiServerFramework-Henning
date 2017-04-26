using System.Web.Mvc;
using EPiServer.Web.Mvc;
using Knowit.EpiserverFramework.Models.Media;

namespace Knowit.EpiserverFramework.Web.Features.Media.ImageMedia
{
    /// <summary>
    /// Image media controller
    /// </summary>
    public class ImageMediaController : PartialContentController<ImageMediaModel>
    {
        public override ActionResult Index(ImageMediaModel currentContent)
        {
            var model = new ImageMediaViewModel(currentContent);
            
            return PartialView(model);
        }
    }
}