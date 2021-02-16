using Pentagono.Spock.Module.BusinessObjects;
using System;
using System.Data;
using System.Linq;

namespace Pentagono.Spock.Module.DatabaseUpdate.Seeders
{
    class VehicleBrandSeeder : Seeder
    {
        private const string FILE_NAME = "VehicleBrand.csv";

        public VehicleBrandSeeder(Updater updater) : base(updater) { }
        public override void Run()
        {
            bool isPopulated = (from c in Query<VehicleBrand>() select c).Any();

            DataTable csvData = ReadCsv(FILE_NAME);
            if (!isPopulated)
            {
                foreach (DataRow row in csvData.Rows)
                {
                    new VehicleBrand(Session)
                    {
                        Name = Convert.ToString(row["Name"]).Trim(),
                        Company = Convert.ToString(row["Company"]).Trim()
                    };
                }
            }
        }

    }
}
