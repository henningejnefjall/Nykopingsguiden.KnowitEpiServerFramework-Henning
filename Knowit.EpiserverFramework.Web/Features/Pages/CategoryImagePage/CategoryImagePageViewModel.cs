using Knowit.EpiserverFramework.Models.Pages;
using Knowit.EpiserverFramework.Models.ViewModels;

namespace Knowit.EpiserverFramework.Web.Features.Pages.CategoryImagePage
{
    /// <summary>
    /// Category image page view model
    /// </summary>
    public class CategoryImagePageViewModel : PageViewModel<CategoryImagePageModel>
    {
        public CategoryImagePageViewModel(CategoryImagePageModel currentPage) : base(currentPage)
        {
        }
    }
}