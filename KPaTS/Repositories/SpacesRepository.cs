using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KPaTS.Models;

namespace KPaTS.Repositories
{
    public class SpacesRepository
    {
        public bool AddSpace(string name)
        {
            using (var DB = new MainContext())
            {
                DB.Spaces.Add(new SpaceModel(){
                    Name = name
                });
                DB.SaveChanges();
                return true;
            }
            return false;
        }

    }
}