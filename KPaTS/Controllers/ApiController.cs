using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KPaTS.Core.Algorithms;
using KPaTS.Repositories;
using KPaTS.Models;

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

        public JsonResult GetAutocompleteItems(string query)
        {
            dynamic data = AutocompleteAlgorithms.ParseQuery(query);
            return Json(new TestsRepository().GetTestsForAutocomplete(data.space, data.test), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetSpaceSubjects(Guid id)
        {
            return Json(new SubjectsRepository().GetSpaceSubjects(id), JsonRequestBehavior.AllowGet);
        }

        public JsonResult CheckTestShortcut(string shortcut)
        {
            return Json(new { result = (new TestsRepository().GetTestByShortcut(shortcut) != null) ? 0 : 1 }, JsonRequestBehavior.AllowGet);
        }

        public PartialViewResult SearchInfo(string query)
        {
            List<InfoModel> info = new InfosRepository().GetInfos();
            return PartialView("~/Views/Test/_InfoSearchPartialView.cshtml", info);
        }

        public PartialViewResult RenderInfoPiece(Guid infoGuid, int index)
        {
            ViewBag.InfoIndex = index;
            InfoModel info = new InfosRepository().GetInfoById(infoGuid);
            return PartialView("~/Views/Test/_InfoPiecePartial.cshtml", info);
        }

        public JsonResult PreviewInfo(Guid infoGuid)
        {
            InfoModel info = new InfosRepository().GetInfoById(infoGuid);
            return Json(info.Body, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetInfoForQuestion(Guid testId, int questionIndex)
        {
            TestModel test = new TestsRepository().GetTest(testId);
            InfoModel info = test.Infos.FirstOrDefault();
            return Json(info.StrippedBody, JsonRequestBehavior.AllowGet);
        }
    }
}
