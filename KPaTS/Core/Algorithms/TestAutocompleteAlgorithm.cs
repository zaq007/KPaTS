using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KPaTS.Models;

namespace KPaTS.Core.Algorithms
{
    public class TestAutocompleteAlgorithm
    {
        public static bool isSuitable(TestModel test, string query)
        {
            var split = query.ToLower().Split(Constants.TEST_SPACE_SEPARATOR);
            int sepCount = split.Count();
            string name = query;
            string space = null;
            if (sepCount > 2)
                return false;
            if (sepCount == 2)
            {
                space = split[1];
                name = split[0];
            }
            if (String.Compare(test.Space.Name, space, true) != 0)
                return false;
            for (int i = 0; i < name.Length; i++)
                if (test.Name.ToLower()[i] != name[i])
                    return false;
            return true;
        }

    }
}