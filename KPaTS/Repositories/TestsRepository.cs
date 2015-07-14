using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KPaTS.Models;

namespace KPaTS.Repositories
{
    public class TestsRepository
    {
        public TestModel GetTest(Guid guid)
        {
            using (var DB = new MainContext())
            {
                return DB.Tests.Where(x => x.Id == guid).FirstOrDefault();
            }
        }
    }
}