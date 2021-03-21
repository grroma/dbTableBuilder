using System;
using System.Collections.Generic;
using dbTableBuilder.Interfaces;
using Xceed.Document.NET;
using Xceed.Words.NET;
using Table = dbTableBuilder.Models.Table;

namespace dbTableBuilder.FileCreator
{
    public class FileCreator : IFileCreator
    {
        public void Create(IEnumerable<Table> tables, string filePath)
        {
            try
            {
                var doc = DocX.Create(filePath);
                foreach (var table in tables)
                {
                    doc.InsertParagraph();
                    doc.InsertParagraph($"{table.Name}");
                    var t = doc.AddTable( table.Rows.Count+1, 3 );
                    t.Design = TableDesign.TableGrid;
                    t.Rows[0].Cells[0].Paragraphs[0].Append("Атрибут");
                    t.Rows[0].Cells[1].Paragraphs[0].Append("Тип данных");
                    t.Rows[0].Cells[2].Paragraphs[0].Append("NULLABLE");
                    
                    var rowIndex = 1 ;
                    while (rowIndex < table.Rows.Count)
                    {
                        foreach (var row in table.Rows)
                        {
                            t.Rows[rowIndex].Cells[0].Paragraphs[0].Append(row.Name);
                            t.Rows[rowIndex].Cells[1].Paragraphs[0].Append(row.DataType);
                            t.Rows[rowIndex].Cells[2].Paragraphs[0].Append(row.IsNullable);
                            rowIndex++;
                        }
                    }
                    doc.InsertTable(t);
                }
                doc.Save();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}