﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AnkietaAlkoholowa
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("");
            routes.IgnoreRoute("Home");
            //routes.IgnoreRoute("Home/Sessione/");





            routes.MapRoute(
                "Graph",
                "Home/Graph/{sex}/{age}",
                new { controller = "Home", action = "Graph" }
                )
            ;

           
            //routes.MapRoute(
            //    "Sessione",
            //    "{controller}/{action}/{id}",
            //    new {controller = "Home", action = "Sessione", id = UrlParameter.Optional}

            //);
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
