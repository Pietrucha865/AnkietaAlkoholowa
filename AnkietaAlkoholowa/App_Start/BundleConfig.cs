﻿using System.Web;
using System.Web.Optimization;

namespace AnkietaAlkoholowa
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {

            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/bootstrap.min.css","~/Content/bootstrap.css", "~/Content/Site.css"));


            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include("~/Scripts/bootstrap.min.js", "~/Scripts/Chart.js"));
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include("~/Scripts/jquery-1.9.1.min.js","~/Scripts/jquery-ui.js"));
          


            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.



        }
    }
}
