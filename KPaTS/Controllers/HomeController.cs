using KPaTS.Core;
using KPaTS.Core.Algorithms;
using KPaTS.Models;
using KPaTS.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KPaTS.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return PartialView();
        }

        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public PartialViewResult GetAutocompleteResults(string query)
        {
            dynamic data = AutocompleteAlgorithms.ParseQuery(query);
            List<AutocompleteInfo> tests = new TestsRepository().GetAutocompleteItems(data.space, data.test);
            List<AutocompleteInfo> spaces = new SpacesRepository().GetAutocompleteItems(data.space, data.test);
            return PartialView(spaces.Union(tests).ToList());
        }
    }
}
