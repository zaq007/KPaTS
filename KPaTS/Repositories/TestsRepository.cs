using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KPaTS.Core.Algorithms;
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

        public TestModel GetTestByShortcut(string @short)
        {
            using (var DB = new MainContext())
            {
                return DB.Tests.Where(x => string.Compare(x.Shortcut, @short, true) == 0).FirstOrDefault();
            }
        }

        public bool Add(TestModel model)
        {
            model.Creator = new UserProfile()
            {
                UserId = WebMatrix.WebData.WebSecurity.CurrentUserId
            };
            using(var DB = new MainContext())
            {
                DB.Tests.Add(model);
                DB.Entry(model.Space).State = System.Data.Entity.EntityState.Unchanged;
                DB.Entry(model.Subject).State = System.Data.Entity.EntityState.Unchanged;
                DB.Entry(model.Creator).State = System.Data.Entity.EntityState.Unchanged;
                DB.SaveChanges();
                return true;
            }
            return false;
        }

        public List<TestInfoModel> GetTestsForAutocomplete(string query)
        {
            using (var DB = new MainContext())
            {
                var tests = DB.Tests.Where(x => TestAutocompleteAlgorithm.matches(x, query))
                    .Select(x => new TestInfoModel()
                    {
                        Url = new UrlHelper().Action("Index", "Test", x.Id),
                        Name = x.Name,
                        Space = x.Space.Name,
                        Rating = x.Rating
                    }).ToList();
                return tests;
            }
        }
    }
}