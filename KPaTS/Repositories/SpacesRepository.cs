using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KPaTS.Models;
using KPaTS.Core.Algorithms;
using KPaTS.Core;

namespace KPaTS.Repositories
{
    public class SpacesRepository : IAutocompleteRepository
    {
        public List<SpaceModel> GetSpaces()
        {
            using (var DB = new MainContext())
            {
                return DB.Spaces.ToList();
            }
        }

        public SpaceModel GetSpaceById(Guid guid)
        {
            using (var DB = new MainContext())
            {
                return DB.Spaces.Where(x => x.Id == guid).FirstOrDefault();
            }
        }

        public bool Edit(SpaceModel data)
        {
            using (var DB = new MainContext())
            {
                DB.Spaces.Attach(data);
                DB.Entry(data).State = System.Data.Entity.EntityState.Modified;
                DB.SaveChanges();
                return true;
            }
            return false;
        }

        public bool Add(SpaceModel data)
        {
            using (var DB = new MainContext())
            {
                DB.Spaces.Add(data);
                DB.SaveChanges();
                return true;
            }
            return false;
        }

        public void Delete(Guid id)
        {
            using (var DB = new MainContext())
            {
                DB.Entry(GetSpaceById(id)).State = System.Data.Entity.EntityState.Deleted;
                DB.SaveChanges();
            }
        }

        public List<SpaceInfoModel> GetSpacesForAutocomplete(string space, string test)
        {
            using (var DB = new MainContext())
            {

                var list = DB.Spaces.AsEnumerable().Select(x => new SpaceInfoModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Space = x.Shortcut,
                    Shortcut = x.Shortcut,
                }).ToList();
                var spaces = list.Where(x => AutocompleteAlgorithms.Matches(x, space, test)).ToList();
                return spaces;
            }
        }

        public List<AutocompleteInfo> GetAutocompleteItems(string space, string test)
        {
            return GetSpacesForAutocomplete(space, test).Cast<AutocompleteInfo>().ToList();
        }
    }
}