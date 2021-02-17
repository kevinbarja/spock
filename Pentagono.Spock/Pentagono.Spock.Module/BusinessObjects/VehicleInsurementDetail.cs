using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using Pentagono.Spock.Module.Annotations;
using Pentagono.Spock.Module.DatabaseUpdate;
using Caption = System.ComponentModel.DisplayNameAttribute;

namespace Pentagono.Spock.Module.BusinessObjects
{
    [Caption("Detalle de seguros vehiculares")]
    [Persistent(Schema.SPOCK + nameof(VehicleInsurementDetail))]
    public class VehicleInsurementDetail : BusinessObject
    {

        public VehicleInsurementDetail(Session session) : base(session) { }

        VehicleInsurement vehicleInsurement;
        decimal tax;
        VehicleType vehicleType;
        City city;

        [Persistent("VehicleInsurement_VehicleInsurement")]
        [Association("VehicleInsurement-VehicleInsurementDetail"), RequiredField]
        public VehicleInsurement VehicleInsurement
        {
            get => vehicleInsurement;
            set => SetPropertyValue(ref vehicleInsurement, value);
        }

        [Caption("Tasa anual")]
        [RequiredField]
        [VisibleInLookupListView(true)]
        [VisibleInListView(true)]
        [VisibleInDetailView(true)]
        [ModelDefault("DisplayFormat", "{0:P2}")]
        public decimal Tax
        {
            get => tax;
            set => SetPropertyValue(ref tax, value);
        }

        [Caption("Tipo de vehículo")]
        [Persistent("VehicleType_VehicleType"), RequiredField]
        public VehicleType VehicleType
        {
            get => vehicleType;
            set => SetPropertyValue(ref vehicleType, value);
        }

        [Caption("Ciudad")]
        [Persistent("City_City"), RequiredField]
        public City City
        {
            get => city;
            set => SetPropertyValue(ref city, value);
        }
    }
}