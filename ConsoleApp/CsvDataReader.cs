namespace ConsoleApp
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using ConsoleApp.Printers;

    public class CsvDataReader : IDataReader<ImportedObject>
    {
        public IEnumerable<ImportedObject> ImportedObjects { get; private set; }
        
        public void ImportData(string fileToImport)
        {
            var importedLines = File.ReadAllLines(fileToImport);
            var importedObjects = importedLines.Select(line => new ImportedObject(line.Split(';'))).ToList();
            
            foreach (var importedObject in importedObjects)
            {
                importedObject.AssignChildren(importedObjects);
            }

            ImportedObjects = importedObjects;
        }

        public void PrintData()
        {
            var databasePrinters = ImportedObjects
                .Where(obj => obj.IsDatabase())
                .Select(db => new DatabasePrinter(db));

            foreach (var printer in databasePrinters)
            {
                printer.Print(ImportedObjects);
            }
        }
    }
}
