using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KPaTS.Core.Algorithms;
using KPaTS.Repositories;
using KPaTS.Models;
using System.Text.RegularExpressions;

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
            return Json(info.StrippedBody, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetInfoForQuestion(Guid testId, int questionIndex)
        {
            InfoModel info = new InfosRepository().GetInfoCreatedForTest(testId);
            var result = "";
            if (info != null)
            {
                string body = info.Body;
                string pattern = String.Format(@"((\S+ *){{6}})(<abbr[^>]* data-question-id=\""{0}\""[^>]*>(.*?)< *\/ *abbr *>)(( *\S+){{6}})", questionIndex);
                Match mainRegex = new Regex(pattern).Match(body);
                Regex selectHtmlTags = new Regex("<[^>]*>");


                result = "..." + selectHtmlTags.Replace(mainRegex.Groups[1].Value, "") + mainRegex.Groups[3].Value + selectHtmlTags.Replace(mainRegex.Groups[5].Value, "") + "...";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}
