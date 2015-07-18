using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KPaTS.Models;

namespace KPaTS.Repositories
{
    public class SubjectsRepository
    {
        public List<SubjectModel> GetSubjects()
        {
            using (var DB = new MainContext())
            {
                return DB.Subjects.ToList();
            }
        }


        public SubjectModel GetSubjectById(Guid guid)
        {
            using (var DB = new MainContext())
            {
                return DB.Subjects.Where(x => x.Id == guid).FirstOrDefault();
            }
        }

        public bool Edit(SubjectModel data)
        {
            using (var DB = new MainContext())
            {
                DB.Subjects.Attach(data);
                DB.Entry(data).State = System.Data.Entity.EntityState.Modified;
                DB.SaveChanges();
                return true;
            }
            return false;
        }

        public bool Add(SubjectModel data)
        {
            using (var DB = new MainContext())
            {
                DB.Subjects.Add(data);
                DB.SaveChanges();
                return true;
            }
            return false;
        }

        public void Delete(Guid id)
        {
            using (var DB = new MainContext())
            {
                DB.Entry(GetSubjectById(id)).State = System.Data.Entity.EntityState.Deleted;
                DB.SaveChanges();
            }
        }

    }
}