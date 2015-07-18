using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KPaTS.Models;

namespace KPaTS.Repositories
{
    public class ProfessorsRepository
    {
        public List<ProfessorModel> GetProfessors()
        {
            using (var DB = new MainContext())
            {
                return DB.Professors.ToList();
            }
        }

        public ProfessorModel GetProfessorById(Guid guid)
        {
            using (var DB = new MainContext())
            {
                return DB.Professors.Where(x => x.Id == guid).FirstOrDefault();
            }
        }

        public bool Edit(ProfessorModel data)
        {
            using (var DB = new MainContext())
            {
                DB.Professors.Attach(data);
                DB.Entry(data).State = System.Data.Entity.EntityState.Modified;
                DB.SaveChanges();
                return true;
            }
            return false;
        }

        public bool Add(ProfessorModel data)
        {
            using (var DB = new MainContext())
            {
                DB.Professors.Add(data);
                DB.SaveChanges();
                return true;
            }
            return false;
        }

        public void Delete(Guid id)
        {
            using (var DB = new MainContext())
            {
                DB.Entry(GetProfessorById(id)).State = System.Data.Entity.EntityState.Deleted;
                DB.SaveChanges();
            }
        }

    }
}