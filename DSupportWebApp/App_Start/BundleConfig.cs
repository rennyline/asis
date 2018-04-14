using System.Web;
using System.Web.Optimization;

namespace DSupportWebApp
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            //            "~/Scripts/jquery-{version}.js"));

            //bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
            //            "~/Scripts/jquery.validate*"));

            //Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //            "~/Scripts/modernizr-*"));

            //bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
            //          "~/Scripts/bootstrap.js",
            //          "~/Scripts/respond.js"));

            //bundles.Add(new StyleBundle("~/Content/css").Include(
            //          "~/Content/bootstrap.css",
            //          "~/Content/site.css"));



            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Content/DSupportWebApp/asset/js/jquery.min.js",
                        "~/Content/DSupportWebApp/asset/js/jquery.ui.min.js",
                        "~/Content/DSupportWebApp/asset/js/main.js"));


            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Content/DSupportWebApp/asset/js/bootstrap.min.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/DSupportWebApp/asset/css/bootstrap.min.css",
                      "~/Content/DSupportWebApp/asset/css/jquery.ui.min.css",
                      "~/Content/DSupportWebApp/asset/css/style.css"));

            bundles.Add(new ScriptBundle("~/bundles/asis_tinyMCE").Include(
                "~/scripts/tinymce/tinymce.min.js",
                "~/scripts/Asis_tinyMCE.js"
                ));
        }
    }
}
