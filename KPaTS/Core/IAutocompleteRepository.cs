using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPaTS.Core
{
    interface IAutocompleteRepository
    {
        List<AutocompleteInfo> GetAutocompleteItems(string space, string test);
    }
}
