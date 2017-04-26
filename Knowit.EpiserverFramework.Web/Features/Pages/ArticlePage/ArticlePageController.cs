using System.Web.Mvc;
using Knowit.EpiserverFramework.Models.Pages;

namespace Knowit.EpiserverFramework.Web.Features.Pages.ArticlePage
{
    /// <summary>
    /// Article page controller
    /// </summary>
        public class ArticlePageController : PageBaseController<ArticlePageModel>
        {
            public ActionResult Index(ArticlePageModel currentPage)
            {
                var model = new ArticlePageViewModel(currentPage);

                return View(model);
            }
        }
    }