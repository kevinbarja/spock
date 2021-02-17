using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using Pentagono.Spock.Module.Annotations;
using Pentagono.Spock.Module.DatabaseUpdate;
using Caption = System.ComponentModel.DisplayNameAttribute;

namespace Pentagono.Spock.Module.BusinessObjects
{
    [Caption("Seguros vehiculares")]
    [Persistent(Schema.SPOCK + nameof(VehicleInsurement))]
    public class VehicleInsurement : BusinessObject
    {
        public static string PATH_NAVIGATION = @"Application/NavigationItems/Items/InsurementTypes/Items/VehicleInsurements";
        public static string AUTO_SEGURO = "Auto seguro";
        public VehicleInsurement(Session session) : base(session) { }

        string description = string.Empty;

        [Caption("Descripción")]
        [VisibleInLookupListView(true)]
        [VisibleInListView(true)]
        [VisibleInDetailView(true)]
        [Size(MEDIUM_STRING_SIZE), Nullable(false), RequiredField]
        public string Description
        {
            get => description;
            set => SetPropertyValue(ref description, value);
        }

        [Caption("Activo")]
        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        [VisibleInDetailView(true)]
        public new bool IsActive
        {
            get => base.IsActive;
            set => base.IsActive = value;
        }

        [Caption("Detalle")]
        [Association("VehicleInsurement-VehicleInsurementDetail"), Aggregated]
        public XPCollection<VehicleInsurementDetail> VehicleInsurementDetail
        {
            get
            {
                return GetCollection<VehicleInsurementDetail>();
            }
        }
    }
}