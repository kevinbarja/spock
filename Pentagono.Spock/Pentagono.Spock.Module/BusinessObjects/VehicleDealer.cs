using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using Pentagono.Spock.Module.Annotations;
using Pentagono.Spock.Module.DatabaseUpdate;
using System.Collections.Generic;
using Caption = System.ComponentModel.DisplayNameAttribute;

namespace Pentagono.Spock.Module.BusinessObjects
{
    [Caption("Concesionarios")]
    [Persistent(Schema.SPOCK + nameof(VehicleDealer))]
    public class VehicleDealer : BusinessObject
    {
        public static string PATH_NAVIGATION = @"Application/NavigationItems/Items/Companies/Items/VehicleDealers";
        public static string IMCRUZ = "Imcruz";

        public VehicleDealer(Session session) : base(session) { }

        string name = string.Empty;

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

        [Caption("Activo")]
        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        [VisibleInDetailView(true)]
        public new bool IsActive
        {
            get => base.IsActive;
            set => base.IsActive = value;
        }

        [Caption("Ejecutivos de ventas")]
        [Association("VehicleDealer-Employees")]
        public XPCollection<Employee> Employees
        {
            get
            {
                return GetCollection<Employee>();
            }
        }

        [MemberDesignTimeVisibility(false)]
        [Association("VehicleDealer-VehicleDealerVehicleBrands")]
        public XPCollection<VehicleDealerVehicleBrand> VehicleDealerVehicleBrands
            => GetCollection<VehicleDealerVehicleBrand>();

        [DisplayName("Marcas de vehículos")]
        [ManyToManyAlias(nameof(VehicleDealerVehicleBrands), nameof(VehicleDealerVehicleBrand.VehicleBrand))]
        public IList<VehicleBrand> VehicleBrands => GetList<VehicleBrand>();
    }
}