using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KPaTS.Models
{
    public class StatModel
    {
        public Guid Id { get; set; }

        public int Count { get; set; }

        public DateTime Date { get; set; }

        public virtual TestModel TestModel { get; set; }

        public virtual UserProfile UserProfile { get; set; }

    }
}