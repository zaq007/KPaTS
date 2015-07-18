using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KPaTS.Areas.Admin.Controllers
{
    [Authorize(Roles="admin")]
    public class HomeController : Controller
    {
        //
        // GET: /Admin/Index/

        public ActionResult Index()
        {
            return View();
        }

    }
}
