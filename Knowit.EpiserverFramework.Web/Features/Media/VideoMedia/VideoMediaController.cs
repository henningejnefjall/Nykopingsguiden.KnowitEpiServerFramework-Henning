using System.Web.Mvc;
using EPiServer.Web.Mvc;
using Knowit.EpiserverFramework.Models.Media;

namespace Knowit.EpiserverFramework.Web.Features.Media.VideoMedia
{
    /// <summary>
    /// Video media controller
    /// </summary>
    public class VideoMediaController : PartialContentController<VideoMediaModel>
    {
        public override ActionResult Index(VideoMediaModel currentContent)
        {
            var model = new VideoMediaViewModel(currentContent);

            return PartialView(model);
        }
    }
}