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
        public void Create(List<Table> tables)
        {
            string fileName = @"C:\Users\oilhe\Desktop\Проекты\dbTableBuilder\dbTableBuilder\DocXExample.docx";

            try
            {
                var doc = DocX.Create(fileName);
                foreach (var table in tables)
                {
                    var t = doc.AddTable( table.Row.Count, 2 );
                    t.Design = TableDesign.TableGrid;
                    for (var i = 0; i < 1; i++)
                    {
                        t.Rows[0].Cells[0].Paragraphs[i].Append(table.Row.Keys.ToString());
                        t.Rows[0].Cells[1].Paragraphs[i].Append(table.Row.Values.ToString());
                    }
                    doc.InsertTable(t);
                    doc.InsertParagraph();
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