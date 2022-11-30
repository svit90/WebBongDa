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

            routes.MapRoute(
             name: "sb_formadd",
             url: "home/add/submit",
             defaults: new { controller = "Home", action = "AddSubmit" }
            );
            ///home/pickteam/" + idteam +"/submit
            ///routes.MapRoute(
            routes.MapRoute(
            name: "sb_pickteam",
             url: "home/pickteam/submit",
             defaults: new { controller = "Home", action = "PickteamSubmit"}
            );
            routes.MapRoute(
            name: "sb_endmatch",
             url: "home/endmatch/submit",
             defaults: new { controller = "Home", action = "EndmatchSubmit" }
            );
            routes.MapRoute(
            name: "sb_blockmatch",
             url: "home/blockmatch/submit",
             defaults: new { controller = "Home", action = "BlockmatchSubmit" }
            );
            routes.MapRoute(
            name: "sb_autoblockmatch",
             url: "tools/autorandom/{id}",
             defaults: new { controller = "Home", action = "AutoBlockRandom", id = UrlParameter.Optional }
            );
            routes.MapRoute(
            name: "sb_autoblockmatchsubmit",
             url: "tools/autorandom-submit/{id}",
             defaults: new { controller = "Home", action = "AutoBlockmatchSubmit", id = UrlParameter.Optional }
            );
        }
    }
}
