using System.Linq;
using System.Web.Mvc;

namespace Knowit.EpiserverFramework.Web.ViewEngine
{
    /// <summary>
    /// View engine registration
    /// </summary>
    public class ViewEngineRegistration
    {
        public static void Register(ViewEngineCollection engines)
        {
            var razorViewEngine = engines.OfType<RazorViewEngine>().FirstOrDefault();

            var contentViewEngine = new ViewEngines();

            if (razorViewEngine == null)
            {
                engines.Add(contentViewEngine);
            }
            else
            {
                var index = engines.IndexOf(razorViewEngine);

                engines.Insert(index, contentViewEngine);
            }
        }
    }
}