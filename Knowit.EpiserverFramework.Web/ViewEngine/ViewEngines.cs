using System.Web.Mvc;

namespace Knowit.EpiserverFramework.Web.ViewEngine
{
    public class ViewEngines : RazorViewEngine
    {
        public ViewEngines()
        {
            var viewLocationFormats = new[]
            {
                "~/Features/Blocks/{1}/{1}{0}.cshtml",
                "~/Features/Pages/{1}/{1}{0}.cshtml",
                "~/Features/Pages/MeetInNykgPages/{1}/{1}{0}.cshtml",
                "~/Features/Plugins/{1}/{1}{0}.cshtml",
                "~/Features/Media/{1}/{1}{0}.cshtml",

                "~/Features/Shared/{0}/{0}.cshtml",
                "~/Features/Shared/DisplayTemplates/{0}.cshtml",
                "~/Features/Shared/{0}.cshtml",

                "~/Features/Pages/TestPage/Partials/_{1}.cshtml",
            };

            ViewLocationFormats = viewLocationFormats;
            PartialViewLocationFormats = viewLocationFormats;
            MasterLocationFormats = viewLocationFormats;

            FileExtensions = new[] { "cshtml" };
        }
    }
}