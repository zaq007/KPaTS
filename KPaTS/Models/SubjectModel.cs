using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KPaTS.Models
{
    public class SubjectModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        public string Shortcut { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<TestModel> Tests { get; set; }

        public ICollection<ProfessorModel> Professors { get; set; }

    }
}