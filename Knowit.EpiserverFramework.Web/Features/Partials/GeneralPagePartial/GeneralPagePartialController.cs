using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Framework.Web;
using EPiServer.Web.Mvc;
using Knowit.EpiserverFramework.Models.Pages;
using Knowit.EpiserverFramework.Web.Features.Pages.GeneralPage;

namespace Knowit.EpiserverFramework.Web.Features.Partials.GeneralPagePartial
{
    [TemplateDescriptor(TemplateTypeCategory = TemplateTypeCategories.MvcPartialController)]
    public class GeneralPagePartialController : PageController<GeneralPageModel>
    {
        public ActionResult Index(GeneralPageModel currentPage)
        {
            var model = new GeneralPageViewModel(currentPage);
            return PartialView(model);
        }
    }
}