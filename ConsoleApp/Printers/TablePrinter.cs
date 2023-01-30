namespace ConsoleApp.Printers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class TablePrinter : IPrinter
    {
        ImportedObject tableImportObj;
        readonly string TableType = "TABLE";
        public TablePrinter(ImportedObject obj)
        {
            tableImportObj = obj;
        }
        public void Print(IEnumerable<ImportedObject> objects)
        {
            if (tableImportObj.Type != TableType)
            {
                Console.WriteLine($"Database printer can only print object with Type = {TableType}");
                return;
            }

            Console.WriteLine($"\tTable '{tableImportObj.Schema}.{tableImportObj.Name}' ({tableImportObj.NumberOfChildren} columns)");
            var columns = objects.Where(column => tableImportObj.IsParentOf(column));

            foreach (var column in columns)
            {
                Console.WriteLine($"\t\tColumn '{column.Name}' with {column.DataType} data type {(column.IsNullable == "1" ? "accepts nulls" : "with no nulls")}");
            }
        }
    }
}
