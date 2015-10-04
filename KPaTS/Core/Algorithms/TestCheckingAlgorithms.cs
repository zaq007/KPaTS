using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KPaTS.Models;
using KPaTS.Repositories;

namespace KPaTS.Core.Algorithms
{
    public class TestCheckingAlgorithms
    {
        public static CheckResultModel CheckTest(TestModel result)
        {
            CheckResultModel check = new CheckResultModel()
            {
                QuestionsCount = result.Questions.Count,
                TestId = result.Id
            };
            foreach (var question in result.Questions)
            {
                if (CheckQuestion(question))
                    check.RightAnswers++;
            }
            return check;
        }

        private static bool CheckQuestion(QuestionModel question)
        {
            using (var DB = new MainContext())
            {
                foreach(var ans in question.Answers)
                {
                    if (DB.Answers.Where(x => x.Id == ans.Id).FirstOrDefault().isRight != ans.isRight)
                        return false;
                }
            }
            return true;
        }

    }
}