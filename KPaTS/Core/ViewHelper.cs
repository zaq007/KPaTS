using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KPaTS.Repositories;

namespace KPaTS.Core
{
    public class ViewHelper
    {
        public static List<SelectListItem> GetSpacesList()
        {
            SpacesRepository repository = new SpacesRepository();
            var list = repository.GetSpaces().Select(x => new SelectListItem()
            {
                Text = x.Shortcut,
                Value = x.Id.ToString(),
                Selected = false
            }).ToList();
            list.Insert(0, new SelectListItem()
            {
                Text = "Space",
                Value = "0",
                Selected = true
            });
            return list;
        }
    }
}