using System.Web.Mvc;
using EPiServer.Web.Mvc;
using Knowit.EpiserverFramework.Models.Media;

namespace Knowit.EpiserverFramework.Web.Features.Media.ExcelMedia
{
    /// <summary>
    /// Excel media controller
    /// </summary>
    public class ExcelMediaController : PartialContentController<ExcelMediaModel>
    {
        public override ActionResult Index(ExcelMediaModel currentContent)
        {
            var model = new ExcelMediaViewModel(currentContent);

            return PartialView(model);
        }
    }
}