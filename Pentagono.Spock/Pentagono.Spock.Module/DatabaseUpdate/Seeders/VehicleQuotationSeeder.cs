using Pentagono.Spock.Module.BusinessObjects;
using System.Linq;

namespace Pentagono.Spock.Module.DatabaseUpdate.Seeders
{
    class VehicleQuotationSeeder : Seeder
    {
        public VehicleQuotationSeeder(Updater updater) : base(updater) { }

        public override void Run()
        {
            bool isPopulated = (from c in Query<VehicleQuotation>() select c).Any();

            if (!isPopulated)
            {
                new VehicleQuotation(Session)
                {
                    Code = "COV000001",
                    PlateNumber = "2487NXH",
                    VehiclePrice = 8000,
                    Time = 1,
                    TimeUnit = BusinessObjects.Enums.TimeUnit.Year,
                    Customer = (from c in Query<Customer>() where c.Email == Customer.PACOSTA_EMAIL select c).FirstOrDefault(),
                    PriceComputed = 240,
                    VehicleInsurement = (from vi in Query<VehicleInsurement>() where vi.Description == VehicleInsurement.AUTO_SEGURO select vi).FirstOrDefault(),
                    City = (from c in Query<City>() where c.Name == City.SANTA_CRUZ select c).FirstOrDefault(),
                    VehicleModel = (from vm in Query<VehicleModel>() where vm.Name == VehicleModel.SWIFT select vm).FirstOrDefault(),
                    //IsActive = false
                };
                
            }
        }
    }
}
