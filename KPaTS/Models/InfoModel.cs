using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KPaTS.Models
{
    public class InfoModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [AllowHtml]
        public string Text { get; set; }

        [Required]
        public string Link { get; set; }

        public virtual TestModel Test { get; set; }
    }
}