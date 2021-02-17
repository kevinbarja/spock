using DevExpress.ExpressApp.ConditionalAppearance;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using Pentagono.Spock.Module.Annotations;
using Pentagono.Spock.Module.BusinessObjects.Enums;
using Pentagono.Spock.Module.DatabaseUpdate;
using Caption = System.ComponentModel.DisplayNameAttribute;
using System.Linq;
using System.ComponentModel;

namespace Pentagono.Spock.Module.BusinessObjects
{
    [DefaultProperty(nameof(Code))]
    [Caption("Cotizaciones vehiculares")]
    [Persistent(Schema.SPOCK + nameof(VehicleQuotation))]
    public class VehicleQuotation : BusinessObject
    {

        public static string PATH_NAVIGATION = @"Application/NavigationItems/Items/Quotations/Items/VehicleQuotations";

        string code = string.Empty;
        string plateNumber;
        int vehiclePrice;
        decimal time;
        TimeUnit timeUnit = TimeUnit.None;
        Customer customer;
        decimal priceComputed;
        VehicleInsurement vehicleInsurement;
        City city;
        VehicleModel vehicleModel;

        public VehicleQuotation(Session session) : base(session) { }



        //[Appearance("CodeDisabled", Enabled = false)]
        [Caption("Código")]
        [Indexed(Unique = true), NonCloneable]
        [VisibleInLookupListView(true)]
        [VisibleInListView(true)]
        [VisibleInDetailView(true)]
        [Size(SMALL_STRING_SIZE), Nullable(false), RequiredField]
        public string Code
        {
            get => code;
            set => SetPropertyValue(ref code, value);
        }

        [Caption("Cliente")]
        [Persistent("Customer_Customer")]
        [VisibleInLookupListView(false)]
        [RequiredField]
        public Customer Customer
        {
            get => customer;
            set => SetPropertyValue(ref customer, value);
        }

        [Caption("Modelo del vehículo")]
        [Persistent("VehicleModel_VehicleModel")]
        [RequiredField]
        public VehicleModel VehicleModel
        {
            get => vehicleModel;
            set => SetPropertyValue(ref vehicleModel, value);
        }

        [Caption("Ciudad")]
        [Persistent("City_City")]
        [RequiredField]
        public City City
        {
            get => city;
            set => SetPropertyValue(ref city, value);
        }

        [Caption("Seguro vehicular")]
        [Persistent("VehicleInsurement_VehicleInsurement")]
        [RequiredField]
        public VehicleInsurement VehicleInsurement
        {
            get => vehicleInsurement;
            set => SetPropertyValue(ref vehicleInsurement, value);
        }

        [Caption("Precio del vehículo (USD)")]
        [VisibleInLookupListView(false)]
        [VisibleInListView(true)]
        [VisibleInDetailView(true)]
        [Nullable(false), RequiredField]
        public int VehiclePrice
        {
            get => vehiclePrice;
            set => SetPropertyValue(ref vehiclePrice, value);
        }

        [Caption("Placa")]
        [VisibleInLookupListView(false)]
        [VisibleInListView(true)]
        [VisibleInDetailView(true)]
        [Size(SMALL_STRING_SIZE), Nullable(false), RequiredField]
        public string PlateNumber
        {
            get => plateNumber;
            set => SetPropertyValue(ref plateNumber, value);
        }

        [Caption("Tiempo")]
        [ToolTip("¿Por qué tiempo desea contratar el seguro?")]
        [VisibleInLookupListView(false)]
        [VisibleInListView(true)]
        [VisibleInDetailView(true)]
        [Nullable(false), RequiredField]
        public decimal Time
        {
            get => time;
            set => SetPropertyValue(ref time, value);
        }

        [VisibleInLookupListView(false)]
        [Caption("Unidad de tiempo")]
        public TimeUnit TimeUnit
        {
            get => timeUnit;
            set => SetPropertyValue(ref timeUnit, value);
        }

        [Caption("Precio calculado")]
        //[Appearance("PriceComputedDisabled", Enabled = false)]
        public decimal PriceComputed
        {
            get => priceComputed;
            set => SetPropertyValue(ref priceComputed, value);
        }

        [Caption("Ejecutivo de ventas")]
        [Appearance("CodeDisabled", Enabled = false)]
        public new Employee CreatedBy
        {
            get {
                //TODO: Implement this, filter createdBy email with employee workEmail
                return (from e in Session.Query<Employee>() where e.WorkEmail == Employee.KBARJA_IMCRUZ_EMAIL select e).FirstOrDefault();
            }
        }

    }
}