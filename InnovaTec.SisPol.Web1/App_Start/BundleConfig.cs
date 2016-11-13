using System.Web;
using System.Web.Optimization;

namespace InnovaTec.SisPol.Web1
{
    public static class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(                         
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/globalize.0.1.3/globalize.js",
                        "~/Scripts/globalize.0.1.3/cultures/globalize.culture.es-PE.js",
                        "~/Scripts/jquery.validate*"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/globalize.0.1.3/globalize.js",
                        "~/Scripts/globalize.0.1.3/cultures/globalize.culture.es-PE.js",
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.min.js",
                      "~/Scripts/respond.min.js",
                      "~/Scripts/jquery.dataTables.min.js",
                      "~/Scripts/pnotify.custom.min.js",
                      "~/Scripts/bootbox.min.js",
                      "~/Scripts/bootstrap-datepicker.js",
                      "~/Scripts/globalize.0.1.3/globalize.js",
                      "~/Scripts/globalize.0.1.3/cultures/globalize.culture.es-PE.js",
                      "~/Scripts/jquery-ui.min.js",
                      "~/Scripts/core.js"
                      ));           

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.min.css",
                      "~/Content/Site.css",
                      "~/Content/css/jquery.dataTables.css",
                      "~/Content/font-awesome.min.css",
                      "~/Content/pnotify.custom.min.css",
                      "~/Content/bootstrap-datepicker.min.css",
                      "~/Content/jquery-ui.min.css"));
        }
    }
}
