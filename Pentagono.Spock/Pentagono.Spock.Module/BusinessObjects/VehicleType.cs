using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using Pentagono.Spock.Module.Annotations;
using Pentagono.Spock.Module.DatabaseUpdate;
using Caption = System.ComponentModel.DisplayNameAttribute;

namespace Pentagono.Spock.Module.BusinessObjects
{
    [Caption("Tipos de vehículos")]
    [Persistent(Schema.SPOCK + nameof(VehicleType))]
    public class VehicleType : BusinessObject
    {
        public static string PATH_NAVIGATION = @"Application/NavigationItems/Items/Params/Items/VehicleTypes";
        public static string AUTO= "Auto";
        public static string VAGONETA= "Vagoneta";
        public static string CAMIONETA= "Camioneta";

        public VehicleType(Session session) : base(session) { }

        string name = string.Empty;

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