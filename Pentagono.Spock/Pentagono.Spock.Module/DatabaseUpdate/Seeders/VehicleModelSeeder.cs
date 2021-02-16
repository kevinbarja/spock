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
                    Type = (from vb in Query<VehicleType>() where vb.Name == VehicleType.AUTO select vb).FirstOrDefault()
                };
                new VehicleModel(Session)
                {
                    Name = VehicleModel.COROLLA,
                    Brand = (from vb in Query<VehicleBrand>() where vb.Name == VehicleBrand.TOYOTA select vb).FirstOrDefault(),
                    Type = (from vb in Query<VehicleType>() where vb.Name == VehicleType.VAGONETA select vb).FirstOrDefault()
                };
                new VehicleModel(Session)
                {
                    Name = VehicleModel.TRITON,
                    Brand = (from vb in Query<VehicleBrand>() where vb.Name == VehicleBrand.MITSUBISHI select vb).FirstOrDefault(),
                    Type = (from vb in Query<VehicleType>() where vb.Name == VehicleType.CAMIONETA select vb).FirstOrDefault()
                };
            }
        }
    }
}
