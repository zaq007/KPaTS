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

    }
}