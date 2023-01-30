namespace ConsoleApp.Printers
{
    using System.Collections.Generic;

    public interface IPrinter
    {
        void Print(IEnumerable<ImportedObject> objects);
    }
}
