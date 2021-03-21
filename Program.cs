using System.Linq;
using dbTableBuilder.Interfaces;

namespace dbTableBuilder
{
    internal static class Program
    {
        // Debug
        private const string ConnectionString = "Host=localhost;Port=5432;Database=mems;User Id=grroma;Password=Q12345q";
        private const string FilePath= @"C:\Users\oilhe\Desktop\Проекты\dbTableBuilder\DocXExample.docx";
        private static void Main(string[] args)
        {
            IDbExtractor extractor = new DbExtractor.DbExtractor();
            var tables = extractor.Extract(args[0]); // input: ConnectionString
            
            IFileCreator writer = new FileCreator.FileCreator();
            writer.Create(tables.ToList(), args[1]);  // input: FilePath
        }
    }
}