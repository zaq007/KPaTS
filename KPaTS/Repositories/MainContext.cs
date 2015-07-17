using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using KPaTS.Models;

namespace KPaTS.Repositories
{
    public class MainContext : DbContext
    {
        public DbSet<ProfessorModel> Professors { get; set; }
        public DbSet<TestModel> Tests { get; set; }
        public DbSet<StatModel> Stats { get; set; }
        public DbSet<QuestionModel> Questions { get; set; }
        public DbSet<AnswerModel> Answers { get; set; }
        public DbSet<InfoModel> Infos { get; set; }
        public DbSet<SpaceModel> Spaces { get; set; }
        public DbSet<SubjectModel> Subjects { get; set; }


        public MainContext()
            : base("DefaultConnection")
        {
            
        }

    }
}