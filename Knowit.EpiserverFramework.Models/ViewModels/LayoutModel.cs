using System.Web.Mvc;

namespace Knowit.EpiserverFramework.Models.ViewModels
{
    /// <summary>
    /// Layout model used for all page views
    /// </summary>
    public class LayoutModel
    {
        public bool HideHeader { get; set; }

        public bool HideFooter { get; set; }

        public bool IsLoggedIn { get; set; }

        public MvcHtmlString LoginUrl { get; set; }

        public MvcHtmlString LogOutUrl { get; set; }
    }
}