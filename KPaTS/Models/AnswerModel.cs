using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KPaTS.Models
{
    public class AnswerModel
    {
        public Guid Id { get; set; }

        public string Text { get; set; }

        public AnswerType Type { get; set; }

        public bool isRight { get; set; }

        public virtual QuestionModel QuestionModel { get; set; }
    }

    public enum AnswerType
    {
        Radio,
        Check,
        Plain
    }
}