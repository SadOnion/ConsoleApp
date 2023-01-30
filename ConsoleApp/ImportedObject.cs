namespace ConsoleApp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ImportedObject
    {
        public string Name { get; set; }
        public string Schema { get; set; }
        public string Type { get; set; }
        public string ParentName { get; set; }
        public string ParentType { get; set; }
        public string DataType { get; set; }
        public string IsNullable { get; set; }
        public int NumberOfChildren { get; set; }

        readonly string databaseType = "DATABASE";

        public ImportedObject(params string[] importData)
        {
            string[] values = new string[7];
            Array.Copy(importData, values, Math.Min(importData.Length, values.Length));
            
            Type = values[0];
            Name = values[1];
            Schema = values[2];
            ParentName = values[3];
            ParentType = values[4];
            DataType = values[5];
            IsNullable = values[6];

            ClearAndCorrect();
        }

        public void AssignChildren(IEnumerable<ImportedObject> importedObjects)
        {
            NumberOfChildren = importedObjects.Count(obj => IsParentOf(obj));
        }

        public bool IsParentOf(ImportedObject obj)
        {
            return obj.ParentName == Name && obj.ParentType == Type;
        }

        public bool IsDatabase() => databaseType == Type;

        private void ClearAndCorrect()
        {
            Type = Purify(Type)?.ToUpper();
            Name = Purify(Name);
            Schema = Purify(Schema);
            ParentName = Purify(ParentName);
            ParentType = Purify(ParentType)?.ToUpper();
        }
        private string Purify(string value)
        {
            return value?.Trim().Replace(Environment.NewLine, "");
        }
    }
}
