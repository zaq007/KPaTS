using KPaTS.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web.Security;

namespace KPaTS.Models
{
    public class TestModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public virtual UserProfile Creator { get; set; }

        [Required]
        public string Shortcut { get; set; }

        public virtual SpaceModel Space { get; set; }

        public long Rating { get; set; }

        public virtual ProfessorModel ProfessorModel { get; set; }

        public virtual SubjectModel Subject { get; set; }

        public virtual ICollection<QuestionModel> Questions { get; set; }

        public virtual ICollection<InfoModel> Infos { get; set; }

        public TestInfoModel ToTestInfoModel()
        {
            return new TestInfoModel()
            {
                Id = this.Id,
                Name = this.Name,
                Space = this.Space.Name,
                Shortcut = this.Shortcut,
                Description = this.Description,
                Rating = this.Rating,
                Creator = this.Creator.UserName
            };
        }
    }

    public class TestInfoModel : AutocompleteInfo
    {
        public override Core.Type Type
        {
            get
            {
                return Core.Type.Test;
            }
        }
        public long Rating { get; set; }
        public string Creator { get; set; }

        public TestInfoModel()
        {
            Name = "Unnamed test";
            Shortcut = "shortcut";
            Description = "Description placeholder";
            Creator = WebMatrix.WebData.WebSecurity.IsAuthenticated ?  Membership.GetUser().UserName : "user";
        }
    }

    public class CheckResultModel
    {
        public Guid TestId { get; set; }
        public int QuestionsCount { get; set; }
        public int RightAnswers { get; set; }
    }
}