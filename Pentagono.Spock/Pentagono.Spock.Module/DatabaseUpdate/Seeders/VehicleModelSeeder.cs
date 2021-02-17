using Pentagono.Spock.Module.BusinessObjects;
using System.Linq;

namespace Pentagono.Spock.Module.DatabaseUpdate.Seeders
{
    class VehicleModelSeeder : Seeder
    {
        public VehicleModelSeeder(Updater updater) : base(updater) { }

        public override void Run()
        {
            bool isPopulated = (from c in Query<VehicleModel>() select c).Any();

            if (!isPopulated)
            {
                new VehicleModel(Session)
                {
                    Name = VehicleModel.SWIFT,
                    Brand = (from vb in Query<VehicleBrand>() where vb.Name == VehicleBrand.SUSUKI select vb).FirstOrDefault(),
                    Type = (from vt in Query<VehicleType>() where vt.Name == VehicleType.AUTO select vt).FirstOrDefault()
                };
                new VehicleModel(Session)
                {
                    Name = VehicleModel.COROLLA,
                    Brand = (from vb in Query<VehicleBrand>() where vb.Name == VehicleBrand.TOYOTA select vb).FirstOrDefault(),
                    Type = (from vt in Query<VehicleType>() where vt.Name == VehicleType.VAGONETA select vt).FirstOrDefault()
                };
                new VehicleModel(Session)
                {
                    Name = VehicleModel.TRITON,
                    Brand = (from vb in Query<VehicleBrand>() where vb.Name == VehicleBrand.MITSUBISHI select vb).FirstOrDefault(),
                    Type = (from vt in Query<VehicleType>() where vt.Name == VehicleType.CAMIONETA select vt).FirstOrDefault()
                };
            }
        }
    }
}
