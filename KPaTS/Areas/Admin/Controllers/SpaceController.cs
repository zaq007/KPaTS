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
    public class SpaceController : Controller
    {
        SpacesRepository repository = new SpacesRepository();

        public ActionResult Index()
        {
            return PartialView(repository.GetSpaces());
        }

        public ActionResult Details(Guid id)
        {
            return View(repository.GetSpaceById(id));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(SpaceModel data)
        {
            bool result = repository.Add(data);
            if (result == false)
                return View(data);
            return RedirectToAction("Details", new { id = data.Id });
        }


        public ActionResult Edit(Guid id)
        {
            return View(repository.GetSpaceById(id));
        }

        [HttpPost]
        public ActionResult Edit(SpaceModel data)
        {
            bool result = repository.Edit(data);
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
