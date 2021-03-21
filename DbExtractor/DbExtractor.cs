using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using dbTableBuilder.Interfaces;
using dbTableBuilder.Models;
using Npgsql;
using Table = dbTableBuilder.Models.Table;

namespace dbTableBuilder.DbExtractor
{
    public class DbExtractor : IDbExtractor
    {
        private const string SqlGetTablesName = 
            @"select table_name 
            from information_schema.tables 
            where table_schema = 'public';";

        public IEnumerable<Table> Extract(string connectionString)
        {
            var connection = Connect(connectionString);
            var extractedTables = ExtractTables(connection);
            var result = (from object name in extractedTables select new Table{Name = name.ToString()}).ToList();
            result = ExtractColumns(result, connection);
            return result;
        }
        
        private NpgsqlConnection Connect(string connectionString)
        {
            var connection = new NpgsqlConnection(connectionString);
            try
            {
                connection.Open();
                Console.WriteLine("Connection successful!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            return connection;
        }
        
        private ArrayList ExtractTables(NpgsqlConnection connection)
        {
            var getTableCommand = new NpgsqlCommand(SqlGetTablesName, connection);
            var reader = getTableCommand.ExecuteReader();
            var nameTables = new ArrayList();
            while (reader.Read())
            {
                for (var i = 0; i < reader.FieldCount; i++)
                {
                    nameTables.Add(reader.GetValue(i));
                }
            }
            reader.Close();
            return nameTables;
        }
        
        private List<Table> ExtractColumns(List<Table> tables, NpgsqlConnection connection)
        {
            foreach (var table in tables)
            {
                table.Rows = new List<Row>();
                var sqlGetColumnName = @$"select column_name, data_type, is_nullable
                from information_schema.columns
                where table_name = '{table.Name}';";
                
                var command = new NpgsqlCommand(sqlGetColumnName, connection);
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    table.Rows.Add(new Row
                    {
                        Name = reader.GetValue(0).ToString(),
                        DataType = reader.GetValue(1).ToString(),
                        IsNullable = reader.GetValue(2).ToString()
                    });
                }
                reader.Close();
            }
            return tables;
        }
    }
}