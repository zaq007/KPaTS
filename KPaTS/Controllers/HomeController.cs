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

        public ActionResult Search(string query)
        {
            dynamic data = AutocompleteAlgorithms.ParseQuery(query);
            if (string.Compare(data.test, "") != 0 && string.Compare(data.space, "") == 0)
            {
                ViewBag.Tests = new TestsRepository().GetTestsForAutocomplete(data.space, data.test);
                if(ViewBag.Tests.Count == 1)
                    return RedirectToAction("Index", "Test", new { Id = ViewBag.Tests[0].Id });
            }
            else
                if (string.Compare(data.space, "") != 0 && string.Compare(data.test, "") == 0)
                {
                    ViewBag.Spaces = new SpacesRepository().GetAutocompleteItems(data.space, data.test);
                    if (ViewBag.Spaces.Count == 1)
                        return RedirectToAction("Index", "Space", new { Id = ViewBag.Spaces[0].Id });
                }
                else
                {
                    var Tests = new TestsRepository().GetTestsForAutocomplete(data.space, data.test);
                    if (Tests.Count == 1)
                        return RedirectToAction("Index", "Test", new { Id = Tests[0].Id });
                }
            return View();
        }
    }
}
