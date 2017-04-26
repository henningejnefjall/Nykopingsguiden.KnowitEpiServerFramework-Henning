using System.Web.Mvc;
using System.Web.Security;
using EPiServer.Web.Mvc;
using Knowit.EpiserverFramework.Models.Core;
using Knowit.EpiserverFramework.Models.ViewModels;

namespace Knowit.EpiserverFramework.Web.Features
{
    /// <summary>
    /// All controllers that renders pages should inherit from this class so that we can 
    /// apply action filters, such as for output caching site wide, should we want to.
    /// </summary>
    /// <typeparam name="T">
    /// Type param T
    /// </typeparam>
    public abstract class PageBaseController<T> : PageController<T>, IModifyLayout where T : SitePageData
    {
        /// <summary>
        /// Signs out the current user and redirects to the Index action of the same controller.
        /// </summary>
        /// <remarks>
        /// There's a log out link in the footer which should redirect the user to the same page. 
        /// As we don't have a specific user/account/login controller but rely on the login URL for 
        /// forms authentication for login functionality we add an action for logging out to all
        /// controllers inheriting from this class.
        /// </remarks>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return this.RedirectToAction("Index");
        }

        public virtual void ModifyLayout(LayoutModel layoutModel)
        {
            var page = PageContext.Page as SitePageData;

            if (page == null)
            {
                return;
            }
        }
    }
}
