using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KPaTS.Models;
using KPaTS.Repositories;

namespace KPaTS.Areas.Admin.Controllers
{
    [Authorize(Roles="admin")]
    public class ProfessorController : Controller
    {
        ProfessorsRepository repository = new ProfessorsRepository();

        public ActionResult Index()
        {
            return PartialView(repository.GetProfessors());
        }

        public ActionResult Details(Guid id)
        {
            return View(repository.GetProfessorById(id));
        }

        [HttpGet]
        public ActionResult Edit(Guid id)
        {
            return View(repository.GetProfessorById(id));
        }

        [HttpPost]
        public ActionResult Edit(ProfessorModel data)
        {
            bool result = repository.Edit(data);
            if(result == false)
                return View(data);
            return RedirectToAction("Details", new { id = data.Id });
        }

        [HttpGet]
        public ActionResult Create()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult Create(ProfessorModel data)
        {
            bool result = repository.Add(data);
            if (result == false)
                return View(data);
            return RedirectToAction("Details", new { id = data.Id });
        }

        [HttpGet]
        public ActionResult Delete(Guid id)
        {
            repository.Delete(id);
            return RedirectToAction("Index");
        }


    }
}
