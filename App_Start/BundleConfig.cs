using System.Web;
using System.Web.Optimization;

namespace ClinicaMVC
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        //"~/Scripts/modernizr-*"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      //"~/Scripts/bootstrap.js",
                      //"~/Scripts/respond.js"
                      ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      //"~/Content/bootstrap.css",
                      //"~/Content/bootstrap.min.css"
                      ////"~/Content/site.css"
                      ));

            //bundles.UseCdn = true;
            //var cdnPath = "//fonts.googleapis.com/css?family=Oswald:400,300,700";
            //bundles.Add(new StyleBundle("~/fonts", cdnPath));

            //var cdnPath1 = "//fonts.googleapis.com/css?family=Open+Sans:400,300,600,700&subset=all";
            //bundles.Add(new StyleBundle("~/fonts1", cdnPath1));

            bundles.Add(new StyleBundle("~/assets/css").Include(                
                      "~/assets/global/plugins/font-awesome/css/font-awesome.min.css",
                      "~/assets/global/plugins/simple-line-icons/simple-line-icons.min.css",
                      "~/assets/global/plugins/bootstrap/css/bootstrap.min.css",
                      "~/assets/global/plugins/uniform/css/uniform.default.css",
                      "~/assets/global/plugins/bootstrap-switch/css/bootstrap-switch.min.css",
                      "~/assets/global/plugins/bootstrap-daterangepicker/daterangepicker.min.css",
                      "~/assets/global/plugins/morris/morris.css",
                      "~/assets/global/plugins/fullcalendar/fullcalendar.min.css",
                      "~/assets/global/plugins/jqvmap/jqvmap/jqvmap.css",        
                      "~/assets/global/css/components.min.css",
                      "~/assets/global/css/plugins.min.css",       
                      "~/assets/layouts/layout5/css/layout.min.css",
                      "~/assets/layouts/layout5/css/custom.min.css",
                      "~/assets/global/plugins/bootstrap-toastr/toastr.min.css"
                ));

            bundles.Add(new ScriptBundle("~/assets/js").Include(
                    "~/assets/global/plugins/jquery.min.js",
                    "~/assets/global/plugins/bootstrap/js/bootstrap.min.js",
                    "~/assets/global/plugins/js.cookie.min.js",
                    "~/assets/global/plugins/bootstrap-hover-dropdown/bootstrap-hover-dropdown.min.js",
                    "~/assets/global/plugins/jquery-slimscroll/jquery.slimscroll.min.js",
                    "~/assets/global/plugins/jquery.blockui.min.js",
                    "~/assets/global/plugins/uniform/jquery.uniform.min.js",
                    "~/assets/global/plugins/bootstrap-switch/js/bootstrap-switch.min.js",        
                    "~/assets/global/plugins/moment.min.js",
                    "~/assets/global/plugins/bootstrap-daterangepicker/daterangepicker.min.js",
                    "~/assets/global/plugins/morris/morris.min.js",
                    "~/assets/global/plugins/morris/raphael-min.js",
                    "~/assets/global/plugins/counterup/jquery.waypoints.min.js",
                    "~/assets/global/plugins/counterup/jquery.counterup.min.js",
                    "~/assets/global/plugins/amcharts/amcharts/amcharts.js",
                    "~/assets/global/plugins/amcharts/amcharts/serial.js",
                    "~/assets/global/plugins/amcharts/amcharts/pie.js",
                    "~/assets/global/plugins/amcharts/amcharts/radar.js",
                    "~/assets/global/plugins/amcharts/amcharts/themes/light.js",
                    "~/assets/global/plugins/amcharts/amcharts/themes/patterns.js",
                    "~/assets/global/plugins/amcharts/amcharts/themes/chalk.js",
                    "~/assets/global/plugins/amcharts/ammap/ammap.js",
                    "~/assets/global/plugins/amcharts/ammap/maps/js/worldLow.js",
                    "~/assets/global/plugins/amcharts/amstockcharts/amstock.js",
                    "~/assets/global/plugins/fullcalendar/fullcalendar.min.js",
                    "~/assets/global/plugins/flot/jquery.flot.min.js",
                    "~/assets/global/plugins/flot/jquery.flot.resize.min.js",
                    "~/assets/global/plugins/flot/jquery.flot.categories.min.js",
                    "~/assets/global/plugins/jquery-easypiechart/jquery.easypiechart.min.js",
                    "~/assets/global/plugins/jquery.sparkline.min.js",
                    "~/assets/global/plugins/jqvmap/jqvmap/jquery.vmap.js",
                    "~/assets/global/plugins/jqvmap/jqvmap/maps/jquery.vmap.russia.js",
                    "~/assets/global/plugins/jqvmap/jqvmap/maps/jquery.vmap.world.js",
                    "~/assets/global/plugins/jqvmap/jqvmap/maps/jquery.vmap.europe.js",
                    "~/assets/global/plugins/jqvmap/jqvmap/maps/jquery.vmap.germany.js",
                    "~/assets/global/plugins/jqvmap/jqvmap/maps/jquery.vmap.usa.js",
                    "~/assets/global/plugins/jqvmap/jqvmap/data/jquery.vmap.sampledata.js",
                    "~/assets/global/scripts/app.min.js",
                    "~/assets/pages/scripts/dashboard.min.js",
                    "~/assets/layouts/layout5/scripts/layout.min.js",
                    "~/assets/layouts/global/scripts/quick-sidebar.min.js",
                    "~/assets/global/plugins/bootstrap-toastr/toastr.min.js"
                ));
        }
    }
}
