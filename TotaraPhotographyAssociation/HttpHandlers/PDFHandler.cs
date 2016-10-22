using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace TotaraPhotographyAssociation.HttpHandlers
{
    public class PDFHandler : IHttpHandler
    {
        public PDFHandler(RequestContext context)
        {
            ProcessRequest(context);
        }

        private static void ProcessRequest(RequestContext requestContext)
        {

            var response = requestContext.HttpContext.Response;
            var request = requestContext.HttpContext.Request;
            var server = requestContext.HttpContext.Server;
            var validRequestFile = requestContext.RouteData.Values["filename"].ToString();
            const string invalidRequestFile = "thief.gif";
            var path = server.MapPath("~/ResFiles/");

            /*
            response.Clear();
            response.ContentType = GetContentType(request.Url.ToString());

            if (request.ServerVariables["HTTP_REFERER"] != null &&
                request.ServerVariables["HTTP_REFERER"].Contains("mikesdotnetting.com"))
            {
                response.TransmitFile(path + validRequestFile);
            }
            else
            {
                response.TransmitFile(path + invalidRequestFile);
            }
            response.End();
            */
        }

        public void ProcessRequest(HttpContext context)
        {
            var d = "d";
        }

        public bool IsReusable
        {
            get { return false; }
        }

    }

}