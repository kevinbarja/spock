using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using Pentagono.Spock.Module.Annotations;
using Pentagono.Spock.Module.DatabaseUpdate;
using Caption = System.ComponentModel.DisplayNameAttribute;

namespace Pentagono.Spock.Module.BusinessObjects
{
    [Caption("Modelos de vehículos")]
    [Persistent(Schema.SPOCK + nameof(VehicleModel))]
    public class VehicleModel : BusinessObject
    {
        public static string PATH_NAVIGATION = @"Application/NavigationItems/Items/Params/Items/VehicleModels";
        public static string SWIFT = "Swift";
        public static string COROLLA = "Corolla";
        public static string TRITON = "Tritón";

        public VehicleModel(Session session) : base(session) { }

        string name = string.Empty;
        VehicleBrand brand;
        VehicleType type;

        [DisplayName("Nombre")]
        [VisibleInLookupListView(true)]
        [VisibleInListView(true)]
        [VisibleInDetailView(true)]
        [Size(MEDIUM_STRING_SIZE), Nullable(false), RequiredField]
        public string Name
        {
            get => name;
            set => SetPropertyValue(ref name, value);
        }

        [Caption("Marca")]
        [Persistent("Brand_VehicleBrand"), RequiredField]
        public VehicleBrand Brand
        {
            get => brand;
            set => SetPropertyValue(ref brand, value);
        }

        [Caption("Tipo")]
        [Persistent("Type_VehicleType"), RequiredField]
        public VehicleType Type
        {
            get => type;
            set => SetPropertyValue(ref type, value);
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
    }
}