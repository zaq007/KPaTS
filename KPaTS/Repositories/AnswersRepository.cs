using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KPaTS.Models;

namespace KPaTS.Repositories
{
    public class AnswersRepository
    {
        public AnswerModel GetAnswer(Guid guid)
        {
            using (var DB = new MainContext())
            {
                return DB.Answers.Where(x => x.Id == guid).FirstOrDefault();
            }
        }
    }
}