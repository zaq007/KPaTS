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
            query = query.ToLower().Trim();
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



        public static bool Matches(AutocompleteInfo info, string space, string test)
        {
            if (test != "" && info.Type == Type.Space)
                return false;

            if (info.Space != null && space != "")
                if (String.Compare(info.Space, space, true) != 0 && space != "")
                    return false;

            if (test != "")
                for (int i = 0; i < test.Length; i++)
                    if (info.Shortcut.ToLower()[i] != test[i])
                        return false;
            return true;
        }
    }
}