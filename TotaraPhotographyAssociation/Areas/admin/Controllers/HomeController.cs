using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TotaraPhotographyAssociation.Areas.admin.Controllers
{

    public class HomeController : Controller
    {
        [Authorize(Roles = "admin")]
        // GET: admin/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}