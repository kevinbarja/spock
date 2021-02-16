using DevExpress.Data.Filtering;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
