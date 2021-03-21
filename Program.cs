using System;
using System.Linq;

namespace dbTableBuilder
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            const string database = "Host=localhost;Port=5432;Database=mems;User Id=grroma;Password=Q12345q";
            var extractor = new DbExtractor.DbExtractor();
            var tables = extractor.Extract(database);
            Console.WriteLine(tables.Count());
            
            var writer = new FileCreator.FileCreator();
            writer.Create(tables.ToList());
        }
    }
}
