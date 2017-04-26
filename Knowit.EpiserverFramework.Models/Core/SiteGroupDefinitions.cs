using System.ComponentModel.DataAnnotations;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Security;

namespace Knowit.EpiserverFramework.Models.Core
{
    /// <summary>
    /// Group definition names for tabs, default content tab starts at 10
    /// </summary>
    [GroupDefinitions]
    public class SiteGroupDefinitions
    {
        [Display(Order = 1)]
        public const string Content = SystemTabNames.Content;

        [Display(Order = 2)]
        public const string Helptexts = "Hjälptexter";

        [Display(Order = 11)]
        public const string General = "general";

        [Display(Order = 13)]
        public const string Header = "header";

        [Display(Order = 14)]
        public const string Footer = "footer";

        [Display(Order = 15)]
        public const string Seo = "seo";

        [Display(Order = 16)]
        public const string Googletools = "googletools";

        [Display(Order = 17)]
        public const string Scriptimports = "scriptimports";

        [RequiredAccess(AccessLevel.Administer)]
        [Display(Order = 18)]
        public const string GlobalSettings = "globalsettings";

        [Display(Order = 19)]
        public const string Test = "test";

        [Display(Order = 50)]
        public const string MeetInNykg = "Mötesplats Nyköping";

        [Display(Order = 99)]
        public const string Admin = "Admin";
    }
}
