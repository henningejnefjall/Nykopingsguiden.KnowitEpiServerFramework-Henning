using System.Web.Mvc;
using EPiServer.Web.Mvc;
using Knowit.EpiserverFramework.Models.Media;

namespace Knowit.EpiserverFramework.Web.Features.Media.DefaultMedia
{
    /// <summary>
    /// Default media controller
    /// </summary>
    public class DefaultMediaController : PartialContentController<DefaultMediaModel>
    {
        public override ActionResult Index(DefaultMediaModel currentContent)
        {
            var model = new DefaultMediaViewModel(currentContent);

            return PartialView(model);
        }
    }
}