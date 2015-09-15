﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
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
                UserId = WebMatrix.WebData.WebSecurity.CurrentUserId,
                UserName = WebMatrix.WebData.WebSecurity.CurrentUserName
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

        public List<TestInfoModel> GetTestsForAutocomplete(string space, string test)
        {
            using (var DB = new MainContext())
            {
                var list = DB.Tests.AsEnumerable().Where(x => AutocompleteAlgorithms.Matches(x, space, test)).ToList();
                var tests = list.Select(x => new TestInfoModel()
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Space = (x.Space != null) ? (x.Space.Name) : (""),
                        Rating = x.Rating,
                        Shortcut = x.Shortcut,
                        Creator = x.Creator.UserName
                    }).ToList();
                return tests;
            }
        }

        /// <summary>
        /// todo: implement algorythm
        /// </summary>
        /// <returns></returns>
        public List<TestInfoModel> GetRecommendedTests()
        {
            using (var DB = new MainContext())
            {
                return DB.Tests.OrderBy(r => Guid.NewGuid()).Take(3)
                    .Select(t => new TestInfoModel()
                    {
                        Shortcut = t.Shortcut,
                        Space = t.Space.Name,
                        Description = t.Description,
                        Rating = t.Rating,
                        Creator = t.Creator.UserName
                    }).ToList();
            }
        }
    }
}