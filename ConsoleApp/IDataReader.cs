using System.Collections.Generic;

namespace ConsoleApp
{
    public interface IDataReader<T>
    {
        IEnumerable<T> ImportedObjects { get; }

        void ImportData(string fileToImport);
        void PrintData();
    }
}