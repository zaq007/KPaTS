using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KPaTS.Models
{
    public class SubjectStyleModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        [Display(Name = "Название стиля")]
        public string Name { get; set; }

        [Required]
        [AllowHtml]
        [Display(Name = "URL фонового изображения")]
        public string BackgroundUrl { get; set; }

        public virtual ICollection<SubjectModel> Subjects { get; set; }
    }
}