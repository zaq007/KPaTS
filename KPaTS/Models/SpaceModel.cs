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
        public string Name { get; set; }

        public virtual ICollection<SubjectModel> Subjects { get; set; }

        public virtual ICollection<TestInfoModel> Tests
        {
            get
            {
                var DB = new MainContext();
                return DB.Tests.Where(x => x.Space.Id == Id).AsEnumerable().Select(x => new TestInfoModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Space = (x.Space != null) ? (x.Space.Shortcut) : (""),
                    Rating = x.Rating,
                    Shortcut = x.Shortcut,
                    Creator = x.Creator.UserName
                }).ToList();
            }
        }
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