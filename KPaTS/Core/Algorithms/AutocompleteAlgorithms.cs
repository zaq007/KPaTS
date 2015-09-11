using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KPaTS.Models;

namespace KPaTS.Core.Algorithms
{
    public class AutocompleteAlgorithms
    {
        public static object ParseQuery(string query)
        {
            if(query[0] == '@')
                return new 
                { 
                    test = "",
                    space = query.Replace("@", "") 
                };
            else
                if (query[0] == '#')
                    return new
                    {
                        test = query.Replace("#", ""),
                        space = ""
                    };
                else
                {
                    var split = query.ToLower().Split(Constants.TEST_SPACE_SEPARATOR);
                    return new
                    {
                        test = split[0],
                        space = split[1]
                    };
                }
        }



        public static bool Matches(TestModel test, string query)
        {
            
            if (String.Compare(test.Space.Name, space, true) != 0)
                return false;
            for (int i = 0; i < name.Length; i++)
                if (test.Name.ToLower()[i] != name[i])
                    return false;
            return true;
        }

    }
}