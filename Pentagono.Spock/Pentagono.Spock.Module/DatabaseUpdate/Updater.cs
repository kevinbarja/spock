using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Updating;
using DevExpress.ExpressApp.Xpo;
using DevExpress.Xpo;
using Pentagono.Spock.Module.DatabaseUpdate.Seeders;
using System;
using System.Reflection;

namespace Pentagono.Spock.Module.DatabaseUpdate {
    // For more typical usage scenarios, be sure to check out https://docs.devexpress.com/eXpressAppFramework/DevExpress.ExpressApp.Updating.ModuleUpdater
    public class Updater : ModuleUpdater {
        public Updater(IObjectSpace objectSpace, Version currentDBVersion) :
            base(objectSpace, currentDBVersion) {
        }

        public override void UpdateDatabaseBeforeUpdateSchema()
        {
            base.UpdateDatabaseBeforeUpdateSchema();
            new SchemaSeeder(this);
        }


        public override void UpdateDatabaseAfterUpdateSchema() {
            base.UpdateDatabaseAfterUpdateSchema();
            new RolSeeder(this);
            new UserSeeder(this);
            new CitySeeder(this);
            new VehicleBrandSeeder(this);
            new VehicleTypeSeeder(this);
            new VehicleModelSeeder(this);
        }


        #region Method for allow the access to functionality of the base class.  
        public int ExecuteNonQueryCommand(string sql)
        {
            return ExecuteNonQueryCommand(sql, false);
        }

        public new IObjectSpace ObjectSpace => base.ObjectSpace;

        public Session Session => ((XPObjectSpace)base.ObjectSpace).Session;

        public Assembly Assembly() => System.Reflection.Assembly.GetExecutingAssembly();
        #endregion
    }
}
