using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace TotaraPhotographyAssociation
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "ProductDetail",
                url: "NewProduct/Detail/{id}",
                defaults: new { controller = "NewProduct", action = "Detail", id = "" },
                namespaces: new[] { "TeAwaOnlineArtworkAuction.Controllers" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "TotaraPhotographyAssociation.Controllers" }
            );
        }
    }
}
