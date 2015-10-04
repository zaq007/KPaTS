using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KPaTS.Core;
using KPaTS.Core.Algorithms;
using KPaTS.Models;
using KPaTS.Repositories;
using WebMatrix.WebData;

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
            dynamic data = AutocompleteAlgorithms.ParseQuery(query);
            return PartialView(new TestsRepository().GetTestsForAutocomplete(data.space, data.test));
        }

        [HttpGet]
        [Authorize]
        public ViewResult Create()
        {
            return View();
        }

        [HttpGet]
        public ViewResult Pass(Guid Id)
        {
            var DB = new MainContext();
            return View(DB.Tests.Where(x => x.Id == Id).FirstOrDefault());
        }

        [HttpPost]
        public ViewResult Pass(TestModel model)
        {
            return View("TestResult", TestCheckingAlgorithms.CheckTest(model));
        }

        [HttpPost]
        [Authorize]
        public ViewResult Create(TestModel model)
        {
            TestsRepository repository = new TestsRepository();
            if (repository.GetTestByShortcut(model.Shortcut) == null)
            {
                var result = new TestsRepository().Add(model);
                if (result == true)
                    ViewBag.Message = Constants.TEST_CREATING_SUCCESS;
                else
                    ViewBag.Message = Constants.TEST_CREATING_ERROR;
                return View(model);
            }
            ViewBag.Message = Constants.TEST_CREATING_ERROR;
            return View(model);
        }

        public ActionResult GetQuestionView(int number, int type)
        {
            ViewBag.number = number;
            ViewBag.type = (QuestionType)type;
            return PartialView("_CreateQuestionPartialView");
        }

        public ActionResult GetAnswerView(int number, int type, int count)
        {
            ViewBag.count = count;
            ViewBag.number = number;
            ViewBag.type = (QuestionType)type;
            return PartialView("_CreateAnswerPartialView");
        }

    }
}
