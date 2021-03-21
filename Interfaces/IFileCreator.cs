using System.Collections.Generic;
using dbTableBuilder.Models;

namespace dbTableBuilder.Interfaces
{
    public interface IFileCreator
    {
        void Create(IEnumerable<Table> tables, string filePath);
    }
}