using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using TotaraPhotographyAssociation.HttpHandlers;

namespace TotaraPhotographyAssociation.RouteHandlers
{
    public class PDFRouteHandler : IRouteHandler
    {
        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            return new PDFHandler(requestContext);
        }
    }
}