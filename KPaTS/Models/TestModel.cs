using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KPaTS.Models
{
    public class TestModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Hash { get; set; }

        public string Space { get; set; }

        public Guid ProfessorModelId { get; set; }

        public virtual ProfessorModel ProfessorModel { get; set; }

        public virtual ICollection<QuestionModel> Questions { get; set; }

        public virtual ICollection<InfoModel> Infos { get; set; }
    }
}