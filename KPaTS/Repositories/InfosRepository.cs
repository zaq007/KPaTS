using KPaTS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KPaTS.Repositories
{
    public class InfosRepository
    {
        public List<InfoModel> GetInfos()
        {
            using (var DB = new MainContext())
            {
                return DB.Infos.ToList();
            }
        }

        public InfoModel GetInfoById(Guid guid)
        {
            using (var DB = new MainContext())
            {
                return DB.Infos.Where(x => x.Id == guid).FirstOrDefault();
            }
        }
    }
}