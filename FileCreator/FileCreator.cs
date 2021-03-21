using System;
using System.Collections.Generic;
using System.Linq;
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
            string fileName = @"C:\Users\oilhe\Desktop\Проекты\dbTableBuilder\DocXExample.docx";

            try
            {
                var doc = DocX.Create(fileName);
                foreach (var table in tables)
                {
                    doc.InsertParagraph();
                    doc.InsertParagraph($"{table.Name}");
                    var t = doc.AddTable( table.Row.Count+1, 3 );
                    t.Design = TableDesign.TableGrid;
                    t.Rows[0].Cells[0].Paragraphs[0].Append("Атрибут");
                    t.Rows[0].Cells[1].Paragraphs[0].Append("Тип данных");
                    t.Rows[0].Cells[2].Paragraphs[0].Append("Описание");
                    
                    var row = 1 ;
                    while (row < table.Row.Count)
                    {
                        foreach (var (key, value) in table.Row)
                        {
                            t.Rows[row].Cells[0].Paragraphs[0].Append(key);
                            t.Rows[row].Cells[1].Paragraphs[0].Append(value);
                            t.Rows[row].Cells[2].Paragraphs[0].Append(string.Empty);
                            row++;
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