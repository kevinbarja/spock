using Pentagono.Spock.Module.BusinessObjects;
using System;
using System.Linq;

namespace Pentagono.Spock.Module.DatabaseUpdate.Seeders
{
    class VehiclePolicySeeder : Seeder
    {
        public VehiclePolicySeeder(Updater updater) : base(updater) { }

        public override void Run()
        {
            bool isPopulated = (from c in Query<VehiclePolicy>() select c).Any();

            if (!isPopulated)
            {
                new VehiclePolicy(Session)
                {
                    Code = "POV000001",
                    VehicleQuotation = (from vq in Query<VehicleQuotation>() where vq.Code == "COT000001" select vq).FirstOrDefault(),
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddYears(1)
                };
            }
        }
    }
}
