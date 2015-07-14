using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KPaTS.Models
{
    public class QuestionModel
    {
        public Guid Id { get; set; }

        public string Text { get; set; }

        public virtual ICollection<AnswerModel> Answers { get; set; }

    }
}