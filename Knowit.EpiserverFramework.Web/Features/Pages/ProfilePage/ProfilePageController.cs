using System.Web.Mvc;
using EPiServer.ServiceLocation;
using EPiServer.Web.Routing;
using Knowit.EpiserverFramework.Business;
using Knowit.EpiserverFramework.Models.Pages;

namespace Knowit.EpiserverFramework.Web.Features.Pages.ProfilePage
{
    /// <summary>
    /// Profile page controller
    /// </summary>
    public class ProfilePageController : PageBaseController<ProfilePageModel>
    {
        private readonly IPageRouteHelper _pageRouteHelper;

        public ProfilePageController(IPageRouteHelper pageRouteHelper)
        {
            _pageRouteHelper = pageRouteHelper;
        }

        public ActionResult Index(ProfilePageModel currentPage)
        {
            var user = EPiServer.Personalization.EPiServerProfile.Current;
            var model = new ProfilePageViewModel(currentPage);

            if (user.IsAnonymous != true)
            {
                var userProfile = new UserViewModel
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.UserName,
                    Address = user["Address"] as string,
                    ZipCode = user["ZipCode"] as string,
                    Locality = user["Locality"] as string
                };

                model.User = userProfile;
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Index(UserViewModel user)
        {
            if (ModelState.IsValid)
            {
                var userProfile = new UserProfileHelper.Profile
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    Address = user.Address,
                    ZipCode = user.ZipCode,
                    Locality = user.Locality
                };
                UserProfileHelper.UpdateUserProfile(userProfile);
                ViewBag.Success = "Din profil är nu uppdaterad";
            }

            var model = new ProfilePageViewModel(_pageRouteHelper.Page as ProfilePageModel) { User = user };

            return View(model);
        }
    }
}