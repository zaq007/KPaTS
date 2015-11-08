using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KPaTS.Core
{
    public enum Type
    {
        Test,
        Space
    }

    public class AutocompleteInfo
    {
        public Guid Id { get; set; }
        public virtual Type Type { get; set; }
        public string Name { get; set; }
        public string Shortcut { get; set; }
        public string Space { get; set; }
        public string Description { get; set; }
    }
}