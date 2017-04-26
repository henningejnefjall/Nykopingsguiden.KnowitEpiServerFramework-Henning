using System.IO;
using System.Net;
using System.Web.Mvc;
using System.Web.Security;
using Knowit.EpiserverFramework.Business;

namespace Knowit.EpiserverFramework.Web.Features.Pages.RegisterPage
{
    /// <summary>
    /// Register page controller
    /// </summary>
    public class RegisterPageController : PageBaseController<Models.Pages.RegisterPageModel>
    {
        // GET: Register
        public ActionResult Index(Models.Pages.RegisterPageModel currentPage)
        {
            var model = new RegisterPageViewModel(currentPage);

            return View(model);
        }

        [HttpPost]
        public ActionResult Index(Models.Pages.RegisterPageModel currentPage, string email, string password)
        {
            /*<add name = "Address" type="System.String" />
            <add name = "ZipCode" type="System.String" />
            <add name = "Locality" type="System.String" />
            <add name = "Email" type="System.String" />
            <add name = "FirstName" type="System.String" />
            <add name = "LastName" type="System.String" />
            <add name = "Company" type="System.String" />
            */

            if (ModelState.IsValid)
            {
                // ReCapcha Secret key 6Lel4QwUAAAAAIOYDGameuJ_GQ_NHD-wnU7Q1Uos
                if (ValidateReCaptcha())
                {
                    // Attempt to register the user
                    MembershipCreateStatus createStatus;
                    Membership.CreateUser(email, password, email, null, null, true, null, out createStatus);

                    if (createStatus == MembershipCreateStatus.Success)
                    {
                        if (!Roles.RoleExists("Companies"))
                        {
                            Roles.CreateRole("Companies");
                        }

                        Roles.AddUserToRole(email, "Companies");
                        FormsAuthentication.SetAuthCookie(email, false /* createPersistentCookie */);

                        //// Business.UserProfileHelper.UpdateUserProfile(new Business.UserProfileHelper.profile { Email = Email, Address = Address, Company = Company, FirstName = FirstName, LastName = LastName, Locality = Locality, ZipCode = ZipCode });
                        // If mail template and subject exists send mail
                        if (!string.IsNullOrEmpty(currentPage.MailSubjectWelcome) || currentPage.MailTemplateWelcome != null)
                        {
                            MailHelper.Send(email, "Nyköpingsguiden <noreply@nykopingsguiden>", currentPage.MailSubjectWelcome, currentPage.MailTemplateWelcome.ToString());
                        }

                        //// Success! Redirect user to chosen TargetPage
                        return RedirectToAction("Index", new { node = currentPage.SuccessTarget });
                    }

                    ModelState.AddModelError(string.Empty, ErrorCodeToString(createStatus));
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Fel i ReCaptcha");
                }
            }

            //// If we got this far, something failed, redisplay form
            return View(currentPage);
        }

        private static string ErrorCodeToString(MembershipCreateStatus createStatus)
        {
            // See http://go.microsoft.com/fwlink/?LinkID=177550 for
            // a full list of status codes.
            switch (createStatus)
            {
                case MembershipCreateStatus.DuplicateUserName:
                    return "Den angivna epostadressen finns redan. Vänligen använd en annan epostadress.";

                case MembershipCreateStatus.DuplicateEmail:
                    return "Den angivna epostadressen finns redan. Vänligen använd en annan epostadress.";

                case MembershipCreateStatus.InvalidPassword:
                    return "Lösenordet är ogiltigt. Var vänlig ange ett giltigt lösenord.";

                case MembershipCreateStatus.InvalidEmail:
                    return "Den angivna epostadressen är ogiltig. Vänligen använd en giltig epostadress.";

                case MembershipCreateStatus.InvalidAnswer:
                    return "Ogiltigt svar, försök igen.";

                case MembershipCreateStatus.InvalidQuestion:
                    return "Ogiltig fråga, försök igen.";

                case MembershipCreateStatus.InvalidUserName:
                    return "Den angivna epostadressen är ogiltig. Vänligen använd en giltig epostadress.";

                case MembershipCreateStatus.ProviderError:
                    return "Systemfel, vänligen kontakta en administratör.";

                case MembershipCreateStatus.UserRejected:
                    return "Användaren kunde inte skapas upp, vänligen kontakta en administratör.";

                default:
                    return "Ett okänt fel har inträffat, vänligen kontakta en administratör.";
            }
        }

        //// POST: /Register
        private bool ValidateReCaptcha()
        {
            var result = Request.Form["g-recaptcha-response"];

            var url = string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}", System.Configuration.ConfigurationManager.AppSettings["ReCaptchaSecret"], result);

            var request = HttpWebRequest.Create(url);

            var objStream = request.GetResponse().GetResponseStream();

            if (objStream != null)
            {
                var objReader = new StreamReader(objStream);
                var googleResults = objReader.ReadToEnd();

                var recaptchaResult = Newtonsoft.Json.JsonConvert.DeserializeObject<ReCaptchaResponse>(googleResults);
                if (!recaptchaResult.Success)
                {
                    ModelState.AddModelError("ReCaptcha", "ReCaptcha is not valid");
                }

                return recaptchaResult.Success;
            }

            return false;
        }

        public class ReCaptchaResponse
        {
            [Newtonsoft.Json.JsonProperty("success")]
            public bool Success { get; set; }

            [Newtonsoft.Json.JsonProperty("error-codes")]
            public string[] ErrorCodes { get; set; }
        }
    }
}