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

        public JsonResult GetSpaceSubjects(Guid id)
        {
            return Json(new SubjectsRepository().GetSpaceSubjects(id), JsonRequestBehavior.AllowGet);
        }

        public JsonResult CheckTestShortcut(string shortcut)
        {
            return Json(new { result = (new TestsRepository().GetTestByShortcut(shortcut) != null) ? 0 : 1 }, JsonRequestBehavior.AllowGet);
        }
    }
}
