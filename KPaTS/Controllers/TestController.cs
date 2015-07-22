using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KPaTS.Models;
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

        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public ViewResult Create(TestModel model)
        {
            var a = this.HttpContext.Request.Params;
            return View();
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
