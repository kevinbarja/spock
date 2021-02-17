using Pentagono.Spock.Module.BusinessObjects;
using System.Linq;

namespace Pentagono.Spock.Module.DatabaseUpdate.Seeders
{
    class VehicleInsurementSeeder : Seeder
    {
        public VehicleInsurementSeeder(Updater updater) : base(updater) { }

        public override void Run()
        {
            bool isPopulated = (from c in Query<VehicleInsurement>() select c).Any();

            if (!isPopulated)
            {
                var vehicleInsurement = new VehicleInsurement(Session)
                {
                    Description = "Auto seguro",
                };
                vehicleInsurement.VehicleInsurementDetail.Add(new VehicleInsurementDetail(Session)
                {
                    VehicleInsurement = vehicleInsurement,
                    Tax = 0.03M,
                    VehicleType = (from vt in Query<VehicleType>() where vt.Name == VehicleType.AUTO select vt).FirstOrDefault(),
                    City = (from c in Query<City>() where c.Name == City.SANTA_CRUZ select c).FirstOrDefault()
                });
            }
        }
    }
}
