using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using TotaraPhotographyAssociation.RouteHandlers;

namespace TotaraPhotographyAssociation
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.Add("PDFRoute", new Route("ResFiles/{filename}", new PDFRouteHandler()));
            routes.IgnoreRoute("{*allpdf}", new { allpdf = @".*\.pdf(/.*)?" });

            routes.IgnoreRoute("{file}.pdf");

            routes.MapRoute(
                name: "ProductDetail",
                url: "NewProduct/Detail/{prdId}",
                defaults: new { controller = "NewProduct", action = "Detail", prdId = "" },
                namespaces: new[] { "TotaraPhotographyAssociation.Controllers" }
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
