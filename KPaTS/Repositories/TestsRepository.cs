using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using KPaTS.Core.Algorithms;
using KPaTS.Models;
using KPaTS.Core;
using System.ComponentModel.DataAnnotations;

namespace KPaTS.Repositories
{
    public class TestsRepository : IAutocompleteRepository
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

        public bool ChangeRating(Guid TestId, int Rating)
        {
            using (var DB = new MainContext())
            {
                var test = DB.Tests.Where(x => x.Id == TestId).FirstOrDefault();
                test.Rating += Rating;
                DB.Entry(test).State = System.Data.Entity.EntityState.Modified;
                DB.SaveChanges();
                return true;
            }
            return false;
        }

        public bool Add(TestModel model)
        {
            model.Creator = new UserProfile()
            {
                UserId = WebMatrix.WebData.WebSecurity.CurrentUserId,
                UserName = WebMatrix.WebData.WebSecurity.CurrentUserName
            };
            using (var DB = new MainContext())
            {
                var context = new ValidationContext(model.Infos.First(), serviceProvider: null, items: null);
                var validationResults = new List<ValidationResult>();

                bool isValid = Validator.TryValidateObject(model.Infos.First(), context, validationResults, true);
                if (isValid)
                {
                    DB.Infos.Add(model.Infos.First());
                    DB.SaveChanges();
                }
                else
                    model.Infos.Remove(model.Infos.First());

                DB.Tests.Add(model);
                DB.Entry(model.Space).State = System.Data.Entity.EntityState.Unchanged;
                DB.Entry(model.Subject).State = System.Data.Entity.EntityState.Unchanged;
                DB.Entry(model.Creator).State = System.Data.Entity.EntityState.Unchanged;

                if (model.Infos != null)
                {
                    foreach (var infoModel in model.Infos)
                    {
                        DB.Entry(infoModel).State = System.Data.Entity.EntityState.Unchanged;
                    }
                }
                DB.SaveChanges();
                return true;
            }
            return false;
        }

        public List<TestInfoModel> GetTestsForAutocomplete(string space, string test)
        {
            using (var DB = new MainContext())
            {
                
                var list = DB.Tests.AsEnumerable().Select(x => new TestInfoModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Space = (x.Space != null) ? (x.Space.Shortcut) : (""),
                    Rating = x.Rating,
                    Shortcut = x.Shortcut,
                    Creator = x.Creator.UserName
                }).ToList();
                var tests = list.Where(x => AutocompleteAlgorithms.Matches(x, space, test)).ToList();
                return tests;
            }
        }

        public List<AutocompleteInfo> GetAutocompleteItems(string space, string test)
        {
            return GetTestsForAutocomplete(space, test).Cast<AutocompleteInfo>().ToList();
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