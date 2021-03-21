using System.Collections.Generic;

namespace dbTableBuilder.Models
{
    public class Table
    {
        public string Name { get; set; }
        public Dictionary<string, string> Row { get; set; }
    }
}