using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KPaTS.Models;

namespace KPaTS.Repositories
{
    public class QuestionsRepository
    {
        public List<QuestionModel> GetTestQuestions(Guid testGuid)
        {
            using (var DB = new MainContext())
            {
                return DB.Tests.Where(x => x.Id == testGuid).FirstOrDefault().Questions.ToList();
            }
        }
    }
}