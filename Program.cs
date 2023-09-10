using dbTableBuilder.Interfaces;
using dbTableBuilder.Services;

namespace dbTableBuilder
{
    public static class Program
    {
        // Example
        // ConnectionString = "Host=localhost;Port=5432;Database=dbname;User Id=user;Password=passwd";
        // FilePath= @"C:\DocXExample.docx";

        public static void Main(string[] args)
        {
            IDbExtractor extractor = new DbExtractor();
            var tables = extractor.Extract(args[0]); // input: ConnectionString
            
            IFileCreator writer = new FileCreator();
            writer.Create(tables, args[1]);  // input: FilePath
        }
    }
}