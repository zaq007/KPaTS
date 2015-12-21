using KPaTS.Core;
using KPaTS.Repositories;
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
        [Display(Name = "Название")]
        public string Name { get; set; }

        public virtual ICollection<SubjectModel> Subjects { get; set; }
    }

    public class SpaceInfoModel : AutocompleteInfo
    {
        public override Core.Type Type
        {
            get
            {
                return Core.Type.Space;
            }
        }

        public SpaceInfoModel()
        {
            Name = "Unnamed space";
            Shortcut = "shortcut";
            Description = "Description placeholder";
        }
    }
}