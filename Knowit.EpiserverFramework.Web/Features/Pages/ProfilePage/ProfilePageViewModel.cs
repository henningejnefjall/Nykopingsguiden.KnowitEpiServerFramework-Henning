using System.ComponentModel.DataAnnotations;
using Knowit.EpiserverFramework.Models.Pages;
using Knowit.EpiserverFramework.Models.ViewModels;

namespace Knowit.EpiserverFramework.Web.Features.Pages.ProfilePage
{
    /// <summary>
    /// Profile page view model
    /// </summary>
    public class ProfilePageViewModel : PageViewModel<ProfilePageModel>
    {
        public ProfilePageViewModel(ProfilePageModel currentPage) : base(currentPage)
        {
        }

        public UserViewModel User { get; set; } = new UserViewModel();
    }

    public class UserViewModel
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        public string Address { get; set; }

        public string ZipCode { get; set; }

        public string Locality { get; set; }
    }
}