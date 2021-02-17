using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using Pentagono.Spock.Module.Annotations;
using Pentagono.Spock.Module.DatabaseUpdate;
using Caption = System.ComponentModel.DisplayNameAttribute;

namespace Pentagono.Spock.Module.BusinessObjects
{
    [Caption("Consesionario - Marca de vehículos")]
    [Persistent(Schema.SPOCK + nameof(VehicleDealerVehicleBrand))]
    public class VehicleDealerVehicleBrand : BusinessObject
    {
        public VehicleDealerVehicleBrand(Session session) : base(session) { }

        VehicleBrand vehicleBrand;
        VehicleDealer vehicleDealer;

        [Persistent("VehicleDealer_VehicleDealer")]
        [Association("VehicleDealer-VehicleDealerVehicleBrands"), RequiredField]
        public VehicleDealer VehicleDealer
        {
            get => vehicleDealer;
            set => SetPropertyValue(ref vehicleDealer, value);
        }

        [Persistent("VehicleBrand_VehicleBrand")]
        [Association("VehicleBrand-VehicleDealerVehicleBrands"), RequiredField]
        public VehicleBrand VehicleBrand
        {
            get => vehicleBrand;
            set => SetPropertyValue(ref vehicleBrand, value);
        }
    }
}