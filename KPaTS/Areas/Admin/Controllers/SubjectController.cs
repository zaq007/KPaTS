using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KPaTS.Models;
using KPaTS.Repositories;

namespace KPaTS.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin")]
    public class SubjectController : Controller
    {
        SubjectsRepository repository = new SubjectsRepository();

        public ActionResult Index()
        {
            return PartialView(repository.GetSubjects());
        }

        public ActionResult Details(Guid id)
        {
            return PartialView(repository.GetSubjectById(id));
        }

        public ActionResult Create()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult Create(SubjectModel data)
        {
            bool result = repository.Add(data);
            if (result == false)
                return View(data);
            return RedirectToAction("Index", "Home");
        }

        
        public ActionResult Edit(Guid id)
        {
            return PartialView(repository.GetSubjectById(id));
        }

        [HttpPost]
        public ActionResult Edit(SubjectModel data)
        {
            bool result = repository.Edit(data);
            if (result == false)
                return View(data);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult Delete(Guid id)
        {
            repository.Delete(id);
            return RedirectToAction("Index", "Home");
        }
    }
}
