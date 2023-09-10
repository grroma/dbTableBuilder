using System.Collections.Generic;

namespace dbTableBuilder.Models
{
    internal class Table
    {
        public string Name { get; init; }
        public List<Row> Rows { get; set; }
    }
}