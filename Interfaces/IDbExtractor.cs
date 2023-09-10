using System.Collections.Generic;
using dbTableBuilder.Models;

namespace dbTableBuilder.Interfaces
{
    internal interface IDbExtractor
    {
        /// <summary>
        /// Get metadata from db
        /// </summary>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        IEnumerable<Table> Extract(string connectionString);
    }
}