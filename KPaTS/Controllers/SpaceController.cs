using KPaTS.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KPaTS.Controllers
{
    public class SpaceController : Controller
    {
        //
        // GET: /Space/

        public ViewResult Index(Guid Id)
        {
            var DB = new MainContext();
            return View(DB.Spaces.Where(x => x.Id == Id).FirstOrDefault());
        }

    }
}
