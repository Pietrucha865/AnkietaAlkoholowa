using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;



namespace AnkietaAlkoholowa
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
           
        }

        //void Session_Start(object sender, EventArgs e)
        //{
        //    // Code that runs when a new session is started

        //    //Response.Redirect("Home/Index");
        //    Session["start"] = true;
        //}


    }
}
