using Pentagono.Spock.Module.BusinessObjects;
using System.Linq;

namespace Pentagono.Spock.Module.DatabaseUpdate.Seeders
{
    class VehicleDealerSeeder : Seeder
    {
        public VehicleDealerSeeder(Updater updater) : base(updater) { }

        public override void Run()
        {
            bool isPopulated = (from c in Query<VehicleDealer>() select c).Any();

            if (!isPopulated)
            {
                var vehicleDealer = new VehicleDealer(Session)
                {
                    Name = VehicleDealer.IMCRUZ,
                };
                vehicleDealer.VehicleDealerVehicleBrands.Add(new VehicleDealerVehicleBrand(Session)
                {
                    VehicleBrand = (from vb in Query<VehicleBrand>() where vb.Name == VehicleBrand.SUSUKI select vb).FirstOrDefault(),
                    VehicleDealer = vehicleDealer
                });

                vehicleDealer.Employees.Add((from e in Query<Employee>() where e.WorkEmail == Employee.KBARJA_IMCRUZ_EMAIL select e).FirstOrDefault());
            }
        }
    }
}
