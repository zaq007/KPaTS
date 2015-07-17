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

        public List<TestAutocompleteModel> GetTestsForAutocomplete(string query)
        {
            using (var DB = new MainContext())
            {
                var tests = DB.Tests.Where(x => TestAutocompleteAlgorithm.isSuitable(x, query))
                    .Select(x => new TestAutocompleteModel()
                    {
                        Url = new UrlHelper().Action("Index", "Test", x.Id),
                        Name = x.Name,
                        Space = x.Space.Name,
                        Stars = x.Stars
                    }).ToList();
                return tests;
            }
        }
    }
}