using System.Collections.Generic;
using dbTableBuilder.Models;

namespace dbTableBuilder.Interfaces
{
    internal interface IFileCreator
    {
        /// <summary>
        /// Create .docx file
        /// </summary>
        /// <param name="tables">Tables metadata</param>
        /// <param name="filePath">File path for output .docx file</param>
        void Create(IEnumerable<Table> tables, string filePath);
    }
}