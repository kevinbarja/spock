using Pentagono.Spock.Module.BusinessObjects;
using System.Linq;

namespace Pentagono.Spock.Module.DatabaseUpdate.Seeders
{
    class VehicleTypeSeeder : Seeder
    {
        public VehicleTypeSeeder(Updater updater) : base(updater) { }

        public override void Run()
        {
            bool isPopulated = (from c in Query<VehicleType>() select c).Any();

            if (!isPopulated)
            {
                new VehicleType(Session)
                {
                    Name = VehicleType.AUTO
                };
                new VehicleType(Session)
                {
                    Name = VehicleType.VAGONETA
                };
                new VehicleType(Session)
                {
                    Name = VehicleType.CAMIONETA
                };

                /*
                new VehicleType(Session)
                {
                    Name = "Moto"
                };
                new VehicleType(Session)
                {
                    Name = "Minibus"
                };
                new VehicleType(Session)
                {
                    Name = "Bus"
                };
                new VehicleType(Session)
                {
                    Name = "Camión"
                };
                */
            }
        }
    }
}
