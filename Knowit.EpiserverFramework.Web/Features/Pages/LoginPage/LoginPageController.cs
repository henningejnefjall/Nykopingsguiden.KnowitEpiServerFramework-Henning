using System;
using System.Web.Mvc;
using System.Web.Security;
using EPiServer;
using EPiServer.Core;
using EPiServer.Security;
using EPiServer.ServiceLocation;
using EPiServer.Web.Mvc.Html;
using Knowit.EpiserverFramework.Business;
using Knowit.EpiserverFramework.Models.Pages;

namespace Knowit.EpiserverFramework.Web.Features.Pages.LoginPage
{
    /// <summary>
    /// Login page controller
    /// </summary>
    public class LoginPageController : PageBaseController<LoginPageModel>
    {
        public ActionResult Index(Models.Pages.LoginPageModel currentPage)
        {
            if (PrincipalInfo.CurrentPrincipal.Identity.IsAuthenticated)
            { 
                return RedirectToAction("Index", new { node = currentPage.SuccessTarget });
            }

            var model = new LoginPageViewModel(currentPage);

            return View(model);           
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginPageModel currentPage, string email, string password, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var u = Server.HtmlEncode(email);
                var p = Server.HtmlEncode(password);
                if (Membership.ValidateUser(u, p))
                {
                    FormsAuthentication.SetAuthCookie(u, false); 
                    if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/") && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                    {
                        return Redirect(returnUrl);
                    }

                    return RedirectToAction("Index", new { node = currentPage.SuccessTarget });
                }

                ModelState.AddModelError(string.Empty, "Inloggningen misslyckades, var god kontrollera ditt användarnamn och lösenord.");
            }

            var model = new LoginPageViewModel(currentPage);

            return View(model);
        }

        public ActionResult Reset(LoginPageModel currentPage)
        {
            var model = new LoginPageViewModel(currentPage);
            return View("~/Features/Pages/LoginPage/LoginPageReset.cshtml", model);
        }

        [HttpPost]
        public ActionResult Reset(LoginPageModel currentPage, string email)
        {
            var model = new LoginPageViewModel(currentPage);

            if (ModelState.IsValid)
            {
                bool changePasswordSucceeded;

                try
                {
                    MembershipUser currentUser = Membership.GetUser(email);
                    if (currentUser != null)
                    {
                        DDSHelper.PasswordReset passwordReset = new DDSHelper.PasswordReset();
                        passwordReset.UserName = email;
                        var key = passwordReset.Key;
                        passwordReset.Save();
                        var domain = HttpContext.Request.Url.Scheme + "://" + HttpContext.Request.Url.Authority;
                        var contentRepository = ServiceLocator.Current.GetInstance<IContentRepository>();

                        var startPage = contentRepository.Get<StartPageModel>(ContentReference.StartPage);
                        SettingsPageModel settingsPage = contentRepository.Get<SettingsPageModel>(startPage.SettingsPage);

                        var urlHelper = ServiceLocator.Current.GetInstance<UrlHelper>();
                        var friendlyUrl = urlHelper.ContentUrl(settingsPage.ChangePasswordPage);

                        var body = model.CurrentPage.EmailTemplate != null ? model.CurrentPage.EmailTemplate.ToString().Replace("{{resetlink}}", string.Format("<a href=\"{0}{1}reset?id={2}\">Återställ lösenord</a>", domain, friendlyUrl, key.ToString())) : string.Empty;

                        MailHelper.Send(currentUser.Email, "Nyköpingsguiden <noreply@nykopingsguiden>", "Återställ lösenord för Nyköpingsguiden", body);
                    }                  

                    // Skriv ut meddelande om lösenordsreset oavsett om användare hittats eller ej för att undvika att funktionen kan användas för sökning av konton
                    ViewBag.Message = "Instruktioner för återställning har skickats till din epostadress.";

                    return View(model);
                }
                catch (Exception ex)
                {
                    changePasswordSucceeded = false;
                }
            }

            return View(model);
        }
    }
}
