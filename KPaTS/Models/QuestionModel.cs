using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KPaTS.Models
{
    public class QuestionModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        [AllowHtml]
        public string Text { get; set; }

        [Required]
        public QuestionType Type { get; set; }

        public virtual ICollection<AnswerModel> Answers { get; set; }

    }


    public enum QuestionType
    {
        [Display(Name = "Единственный верный вариант")]
        Radio,
        [Display(Name = "Несколько верных вариантов")]
        Check,
        [Display(Name = "Без вариантов ответа")]
        Plain
    }
}