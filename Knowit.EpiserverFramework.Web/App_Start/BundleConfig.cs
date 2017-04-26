using System.Web.Optimization;

namespace Knowit.EpiserverFramework.Web
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            // TODO Change to constant
            var styleBundle = new Bundle("~/bundles/CssBundle.css");
            
            // TODO Add all css to bundle
            styleBundle.Include("~/ClientResources/Styles/*.css");

            bundles.Add(styleBundle);
            //// BundleTable.EnableOptimizations = true;
        }
    }
}