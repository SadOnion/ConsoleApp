namespace ConsoleApp.Printers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class DatabasePrinter : IPrinter
    {
        ImportedObject databaseImportedObject;
        readonly string DatabaseType = "DATABASE";
        public DatabasePrinter(ImportedObject obj)
        {
            databaseImportedObject = obj;
        }
        public void Print(IEnumerable<ImportedObject> objects)
        {
            if (databaseImportedObject.Type != DatabaseType)
            {
                Console.WriteLine($"Database printer can only print object with Type = {DatabaseType}");
                return;
            }

            var tables = objects.Where(table => databaseImportedObject.IsParentOf(table));
            foreach (var table in tables)
            {
                new TablePrinter(table).Print(objects);
            }
        }
    }
}
