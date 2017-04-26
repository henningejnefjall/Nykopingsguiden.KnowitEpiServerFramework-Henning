using Knowit.EpiserverFramework.Models.Pages;
using Knowit.EpiserverFramework.Models.ViewModels;

namespace Knowit.EpiserverFramework.Web.Features.Pages.ContainerPage
{
    /// <summary>
    /// Container page view model
    /// </summary>
    public class ContainerPageViewModel : PageViewModel<ContainerPageModel>
    {
        public ContainerPageViewModel(ContainerPageModel currentPage) : base(currentPage)
        {
        }
    }
}