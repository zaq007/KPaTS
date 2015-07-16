using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KPaTS.Repositories;

namespace KPaTS.Controllers
{
    public class TestController : Controller
    {
        //
        // GET: /Test/

        public ActionResult Index(Guid? testId)
        {
            return View(testId);
        }

        [HttpPost]
        public PartialViewResult GetTestsAutocomplete(string query)
        {
            return PartialView(new TestsRepository().GetTestsForAutocomplete(query));
        }

    }
}
