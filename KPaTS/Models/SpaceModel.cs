using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KPaTS.Models
{
    public class SpaceModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        // @shortcut
        [Required]
        public string Shortcut { get; set; }

        [Required]
        public string Name { get; set; }
    }
}