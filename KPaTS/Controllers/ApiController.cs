using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KPaTS.Repositories;

namespace KPaTS.Controllers
{
    
    public class ApiController : Controller
    {
        public JsonResult GetAllProfessors()
        {
            return Json(new ProfessorsRepository().GetProfessors(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetTestQuestions(Guid testGuid)
        {
            return Json(new QuestionsRepository().GetTestQuestions(testGuid), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAnswer(Guid guid)
        {
            return Json(new AnswersRepository().GetAnswer(guid), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetTestsAutocomplete(string query)
        {
            return Json(new TestsRepository().GetTestsForAutocomplete(query), JsonRequestBehavior.AllowGet);
        }


    }
}
