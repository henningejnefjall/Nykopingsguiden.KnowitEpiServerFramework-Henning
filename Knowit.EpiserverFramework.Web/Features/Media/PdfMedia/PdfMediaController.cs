using System.Web.Mvc;
using EPiServer.Web.Mvc;
using Knowit.EpiserverFramework.Models.Media;

namespace Knowit.EpiserverFramework.Web.Features.Media.PdfMedia
{
    /// <summary>
    /// PDF media controller
    /// </summary>
    public class PdfMediaController : PartialContentController<PdfMediaModel>
    {
        public override ActionResult Index(PdfMediaModel currentContent)
        {
            var model = new PdfMediaViewModel(currentContent);

            return PartialView(model);
        }
    }
}