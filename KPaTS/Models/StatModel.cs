using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KPaTS.Models
{
    public class StatModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public int Count { get; set; }

        public DateTime Date { get; set; }

        public virtual TestModel TestModel { get; set; }

        public virtual UserProfile UserProfile { get; set; }

    }
}