using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KPaTS.Core;
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
            return PartialView(new TestsRepository().GetTestsForAutocomplete(query));
        }

        [HttpGet]
        [Authorize]
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public ViewResult Create(TestModel model)
        {
            var result = new TestsRepository().Add(model);
            if (result == true)
                ViewBag.Message = Constants.TEST_CREATING_SUCCESS;
            else
                ViewBag.Message = Constants.TEST_CREATING_ERROR;
            return View(model);
        }

        public ActionResult GetQuestionView(int number, int type)
        {
            ViewBag.number = number;
            ViewBag.type = (QuestionType)type;
            return PartialView("_QuestionPartialView");
        }

        public ActionResult GetAnswerView(int number, int type, int count)
        {
            ViewBag.count = count;
            ViewBag.number = number;
            ViewBag.type = (QuestionType)type;
            return PartialView("_AnswerPartialView");
        }

    }
}
