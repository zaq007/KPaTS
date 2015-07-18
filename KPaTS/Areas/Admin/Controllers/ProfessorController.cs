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

        public ActionResult Index()
        {
            return View(new ProfessorsRepository().GetProfessors());
        }

        public ActionResult Details(Guid id)
        {
            return View(new ProfessorsRepository().GetProfessorById(id));
        }

        [HttpGet]
        public ActionResult Edit(Guid id)
        {
            return View(new ProfessorsRepository().GetProfessorById(id));
        }

        [HttpPost]
        public ActionResult Edit(ProfessorModel data)
        {
            bool result = new ProfessorsRepository().Edit(data);
            if(result == false)
                return View(data);
            return RedirectToAction("Details", new { id = data.Id });
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ProfessorModel data)
        {
            bool result = new ProfessorsRepository().Add(data);
            if (result == false)
                return View(data);
            return RedirectToAction("Details", new { id = data.Id });
        }

        [HttpGet]
        public ActionResult Delete(Guid id)
        {
            new ProfessorsRepository().Delete(id);
            return RedirectToAction("Index");
        }


    }
}
