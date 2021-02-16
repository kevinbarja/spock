using DevExpress.Data.Filtering;
using DevExpress.Xpo;
using System.Linq;
using System.Text;
using System.Data;
using Microsoft.VisualBasic.FileIO;

namespace Pentagono.Spock.Module.DatabaseUpdate.Seeders
{
    public abstract class Seeder
    {

        public Seeder(Updater updater)
        {
            Updater = updater;
            Run();
            SaveChanges();
        }

        public Updater Updater { get; set; }

        public Session Session
        {
            get { return Updater.Session; }
        }

        public abstract void Run();


        public int ExecuteNonQueryCommand(string sql)
        {
            return Updater.ExecuteNonQueryCommand(sql);
        }

        public ObjectType GetObjectByKey<ObjectType>(object key)
        {
            return Updater.ObjectSpace.GetObjectByKey<ObjectType>(key);
        }
        public ObjectType FindObject<ObjectType>(CriteriaOperator criteria)
        {
            return Updater.ObjectSpace.FindObject<ObjectType>(criteria);
        }

        public ObjectType CreateObject<ObjectType>()
        {
            return Updater.ObjectSpace.CreateObject<ObjectType>();
        }
        public XPQuery<T> Query<T>()
        {
            return Updater.Session.Query<T>();
        }

        public void SaveChanges()
        {
            Updater.ObjectSpace.CommitChanges();
        }

        public DataTable ReadCsv(string csvName)
        {
            var assembly = Updater.Assembly();
            var resources = assembly.GetManifestResourceNames();
            string resourceName = assembly.GetManifestResourceNames()
                .Single(str => str.EndsWith("." + csvName));
            DataTable csvData = new DataTable();
            using (TextFieldParser csvReader = new TextFieldParser(assembly.GetManifestResourceStream(resourceName), Encoding.GetEncoding("iso-8859-1"), false))
            {
                csvReader.TextFieldType = FieldType.Delimited;
                csvReader.SetDelimiters(";");
                csvReader.HasFieldsEnclosedInQuotes = false;

                string[] columns = csvReader.ReadFields();
                foreach (string column in columns)
                {
                    DataColumn csvColumn = new DataColumn(column);
                    csvColumn.AllowDBNull = true;
                    csvData.Columns.Add(csvColumn);
                }

                while (!csvReader.EndOfData)
                {
                    string[] rowData = csvReader.ReadFields();
                    for (int i = 0; i < rowData.Length; i++)
                    {
                        if (rowData[i] == "")
                        {
                            rowData[i] = null;
                        }
                    }
                    csvData.Rows.Add(rowData);
                }
            }
            return csvData;
        }
    }
}
