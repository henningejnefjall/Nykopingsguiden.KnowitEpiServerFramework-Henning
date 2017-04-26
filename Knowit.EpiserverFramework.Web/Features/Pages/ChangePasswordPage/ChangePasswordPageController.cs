using System;
using System.Web.Mvc;
using System.Web.Security;
using Knowit.EpiserverFramework.Business;

namespace Knowit.EpiserverFramework.Web.Features.Pages.ChangePasswordPage
{
    /// <summary>
    /// Change password page controller
    /// </summary>
    public class ChangePasswordPageController : PageBaseController<Models.Pages.ChangePasswordPageModel>
    {
        public ActionResult Index(Models.Pages.ChangePasswordPageModel currentPage)
        {
            var model = new ChangePasswordPageViewModel(currentPage);

            return View(model);
        }

        [HttpPost]
        public ActionResult Index(Models.Pages.ChangePasswordPageModel currentPage, string oldPassword, string newPassword)
        {
            if (ModelState.IsValid)
            {
                bool changePasswordSucceeded;
                try
                {
                    MembershipUser currentUser = Membership.GetUser(User.Identity.Name, true /* userIsOnline */);

                    changePasswordSucceeded = currentUser.ChangePassword(oldPassword, newPassword);
                }
                catch (Exception ex)
                {
                    changePasswordSucceeded = false;
                    ViewBag.NoSuccess = "Byte av lösenord har misslyckats";
                }

                if (changePasswordSucceeded)
                { 
                    ViewBag.Success = "Ditt lösenord är nu uppdaterat";
                }
                else
                { 
                    ViewBag.NoSuccess = "Byte av lösenord har misslyckats";
                }
            }
            
            return Redirect("/");
        }

        [HttpPost]
        public ActionResult Reset(Models.Pages.ChangePasswordPageModel currentPage, string id, string newPassword)
        {
            if (ModelState.IsValid)
            {
                bool changePasswordSucceeded;
                try
                {
                    if (!string.IsNullOrEmpty(id))
                    {
                        var passwordReset = DDSHelper.PasswordReset.GetPasswordReset(Guid.Parse(id));
                        if (passwordReset != null)
                        {
                            MembershipUser currentUser = Membership.GetUser(passwordReset.UserName, true /* userIsOnline */);
                            string generatedPassword = currentUser.ResetPassword();
                            changePasswordSucceeded = currentUser.ChangePassword(generatedPassword, newPassword);
                            if (changePasswordSucceeded)
                            {
                                DDSHelper.PasswordReset.Delete(passwordReset);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    changePasswordSucceeded = false;
                }
            }

            return Redirect("/");
        }

        [HttpPost]
        public ActionResult View(Models.Pages.ChangePasswordPageModel currentPage, DDSHelper.PasswordReset passwordReset)
        {
            //// MembershipUser currentUser = Membership.GetUser(passwordReset.UserName, true);
            //// FormsAuthentication.SetAuthCookie(currentUser.UserName, false);

            var model = new ChangePasswordPageViewModel(currentPage);

            return View(model);
        }

        public ActionResult Reset(Models.Pages.ChangePasswordPageModel currentPage, string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                Guid key = Guid.Parse(id);
                var passwordReset = DDSHelper.PasswordReset.GetPasswordReset(key);
                if (passwordReset != null)
                {
                    if (passwordReset.Expires >= DateTime.Now)
                    {
                        return View(currentPage, passwordReset);
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Återställningslänken är utgången");

                        DDSHelper.PasswordReset.Delete(passwordReset);

                        //// return View(currentPage);
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Återställning saknas för angivet id");

                    //// return View(currentPage);
                }
            }

            // if ID is empty or if no passwordreset is found, redirect to root
            return Redirect("/");
        }
    }
}