using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BongDa
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
               name: "Homee",
               url: "",
               defaults: new { controller = "Home", action = "Wellcome"}
           );

            routes.MapRoute(
               name: "Login",
               url: "verify/{code}",
               defaults: new { controller = "Home", action = "Verify", code = UrlParameter.Optional }
           );

            routes.MapRoute(
                name: "Default",
                url: "home/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            //login/define/
            routes.MapRoute(
                name: "Define",
                url: "login",
                defaults: new { controller = "Home", action = "LoginDefine" }
            );
            routes.MapRoute(
               name: "Log out",
               url: "logout",
               defaults: new { controller = "Home", action = "Logout" }
           );
        }
    }
}
