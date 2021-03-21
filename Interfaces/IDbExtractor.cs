using System.Collections.Generic;
using dbTableBuilder.Models;

namespace dbTableBuilder.Interfaces
{
    public interface IDbExtractor
    {
        IEnumerable<Table> Extract(string connectionString);
    }
}