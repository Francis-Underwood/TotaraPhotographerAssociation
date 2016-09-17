using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TotaraPhotographyAssociation.Controllers
{
    public class ResourceController : Controller
    {
        // GET: Resource
        [Authorize(Roles = "full,associate")]
        public ActionResult Index()
        {
            return View();
        }
    }
}