using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KPaTS.Models;

namespace KPaTS.Repositories
{
    public class StatsRepository
    {

        public List<StatModel> GetTestStats(Guid id)
        {
            using (var DB = new MainContext())
            {
                return DB.Stats.Where(x => x.TestModel.Id == id).ToList();
            }
        }

    }
}