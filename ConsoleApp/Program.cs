namespace ConsoleApp
{
    using System;

    internal class Program
    {
        static void Main(string[] args)
        {
            CsvDataReader reader = new CsvDataReader();
            reader.ImportData("data.csv");
            reader.PrintData();
            Console.ReadKey();
        }
    }
}
