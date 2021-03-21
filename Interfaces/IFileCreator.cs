using System.Collections.Generic;
using dbTableBuilder.Models;

namespace dbTableBuilder.Interfaces
{
    public interface IFileCreator
    {
        void Create(List<Table> tables);
    }
}