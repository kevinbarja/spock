using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using Pentagono.Spock.Module.Annotations;
using Pentagono.Spock.Module.DatabaseUpdate;
using Caption = System.ComponentModel.DisplayNameAttribute;

namespace Pentagono.Spock.Module.BusinessObjects
{
    [Caption("Marcas de vehículos")]
    [Persistent(Schema.SPOCK + nameof(VehicleBrand))]
    public class VehicleBrand : BusinessObject
    {
        public static string PATH_NAVIGATION = @"Application/NavigationItems/Items/Params/Items/VehicleBrands";
        public static string SUSUKI = "Suzuki";
        public static string TOYOTA = "Toyota";
        public static string MITSUBISHI = "Mitsubishi";
        public static string CAMIONETA = "Camioneta";

        public VehicleBrand(Session session) : base(session) { }

        string name = string.Empty;
        string company = string.Empty;

        [Caption("Nombre")]
        [VisibleInLookupListView(true)]
        [VisibleInListView(true)]
        [VisibleInDetailView(true)]
        [Size(MEDIUM_STRING_SIZE), Nullable(false), RequiredField]
        public string Name
        {
            get => name;
            set => SetPropertyValue(ref name, value);
        }

        [Caption("Compañía")]
        [VisibleInLookupListView(true)]
        [VisibleInListView(true)]
        [VisibleInDetailView(true)]
        [Size(MEDIUM_STRING_SIZE), Nullable(false), RequiredField]
        public string Company
        {
            get => company;
            set => SetPropertyValue(ref company, value);
        }

        [MemberDesignTimeVisibility(false)]
        [Association("VehicleBrand-VehicleDealerVehicleBrands")]
        public XPCollection<VehicleDealerVehicleBrand> VehicleDealerVehicleBrands
            => GetCollection<VehicleDealerVehicleBrand>();


        [Caption("Activa")]
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