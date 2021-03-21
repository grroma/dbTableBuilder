using System.Collections.Generic;

namespace dbTableBuilder.Models
{
    public class Table
    {
        public string Name { get; set; }
        public List<Row> Rows { get; set; }
    }

    public class Row
    {
        public string Name { get; set; }
        public string DataType { get; set; }
        public string IsNullable { get; set; }
    }
}