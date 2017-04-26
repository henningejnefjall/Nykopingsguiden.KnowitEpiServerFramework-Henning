using Knowit.EpiserverFramework.Models.Pages;
using Knowit.EpiserverFramework.Models.ViewModels;

namespace Knowit.EpiserverFramework.Web.Features.Pages.ArticlePage
{
    /// <summary>
    /// Article page view model
    /// </summary>
    public class ArticlePageViewModel : PageViewModel<ArticlePageModel>
    {
        public ArticlePageViewModel(ArticlePageModel currentPage) : base(currentPage)
        {
        }
    }
}