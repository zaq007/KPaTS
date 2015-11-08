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
            ViewBag.Message = "Измените этот шаблон, чтобы быстро приступить к работе над приложением ASP.NET MVC.";
            ViewBag.RecommendedTests = (new TestsRepository()).GetRecommendedTests();

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Страница описания приложения.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Страница контактов.";

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
