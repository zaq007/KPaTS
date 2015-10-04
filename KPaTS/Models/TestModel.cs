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

        // #shortcut
        [Required]
        public string Shortcut { get; set; }

        public virtual SpaceModel Space { get; set; }

        public long Rating { get; set; }

        public virtual ProfessorModel ProfessorModel { get; set; }

        public virtual SubjectModel Subject { get; set; }

        public virtual ICollection<QuestionModel> Questions { get; set; }

        public virtual ICollection<InfoModel> Infos { get; set; }
    }

    public class TestInfoModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Shortcut { get; set; }
        public string Space { get; set; }
        public string Description { get; set; }
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