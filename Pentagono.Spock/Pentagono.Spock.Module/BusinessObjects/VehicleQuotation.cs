using DevExpress.ExpressApp.ConditionalAppearance;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using Pentagono.Spock.Module.Annotations;
using Pentagono.Spock.Module.BusinessObjects.Enums;
using Pentagono.Spock.Module.DatabaseUpdate;
using Caption = System.ComponentModel.DisplayNameAttribute;
using System.Linq;
using System.ComponentModel;
using System;
using System.Globalization;
using DevExpress.ExpressApp;

namespace Pentagono.Spock.Module.BusinessObjects
{
    [VisibleInReports(true)]
    [DefaultProperty(nameof(Code))]
    [Caption("Cotizaciones vehiculares")]
    [Persistent(Schema.SPOCK + nameof(VehicleQuotation))]
    public class VehicleQuotation : BusinessObject
    {

        public static string PATH_NAVIGATION = @"Application/NavigationItems/Items/Quotations/Items/VehicleQuotations";

        string code = string.Empty;
        string plateNumber;
        decimal vehiclePrice;
        decimal time;
        TimeUnit timeUnit = TimeUnit.Year;
        Customer customer;
        decimal priceComputed;
        VehicleInsurement vehicleInsurement;
        City city;
        VehicleModel vehicleModel;

        public VehicleQuotation(Session session) : base(session) { }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
            string codeComputed = "COV";
            string timestamp = DateTime.UtcNow.ToString("fff",CultureInfo.InvariantCulture);
            codeComputed += timestamp.PadLeft(5, '0');
            Code = codeComputed;
        }


        [Appearance("VehicleQuotationCodeDisabled", Enabled = false)]
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

        [ImmediatePostData]
        [Caption("Modelo del vehículo")]
        [Persistent("VehicleModel_VehicleModel")]
        [RequiredField]
        public VehicleModel VehicleModel
        {
            get => vehicleModel;
            set => SetPropertyValue(ref vehicleModel, value);
        }

        [ImmediatePostData]
        [Caption("Ciudad")]
        [Persistent("City_City")]
        [RequiredField]
        public City City
        {
            get => city;
            set => SetPropertyValue(ref city, value);
        }

        [ImmediatePostData]
        [Caption("Seguro vehicular")]
        [Persistent("VehicleInsurement_VehicleInsurement")]
        [RequiredField]
        public VehicleInsurement VehicleInsurement
        {
            get => vehicleInsurement;
            set => SetPropertyValue(ref vehicleInsurement, value);
        }

        [ImmediatePostData]
        [Caption("Precio del vehículo (USD)")]
        [VisibleInLookupListView(false)]
        [VisibleInListView(true)]
        [VisibleInDetailView(true)]
        [Nullable(false), RequiredField]
        public decimal VehiclePrice
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

        [ImmediatePostData]
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

        [Caption("Precio calculado (-1 si no se logró calcular)")]
        [Appearance("VehicleQuotationPriceComputedDisabled", Enabled = false)]
        public decimal PriceComputed
        {
            get => priceComputed;
            set => SetPropertyValue(ref priceComputed, value);
        }

        [Caption("Ejecutivo de ventas")]
        [Appearance("CodeDisabled", Enabled = false)]
        public new Employee CreatedBy
        {
            get
            {
                //TODO: Implement this, filter createdBy email with employee workEmail
                return (from e in Session.Query<Employee>() where e.WorkEmail == Employee.KBARJA_IMCRUZ_EMAIL select e).FirstOrDefault();
            }
        }

        [Caption("Activo")]
        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        [VisibleInDetailView(false)]
        public new bool IsActive
        {
            get => base.IsActive;
            set => base.IsActive = value;
        }

        protected override void OnChanged(string propertyName, object oldValue, object newValue)
        {
            base.OnChanged(propertyName, oldValue, newValue);
            if (propertyName == nameof(VehicleModel) || propertyName == nameof(City) ||
                propertyName == nameof(VehicleInsurement) || propertyName == nameof(VehiclePrice) ||
                propertyName == nameof(Time))
            {
                if (VehicleModel != null && City != null &&
                    VehicleInsurement != null && VehiclePrice != 0 && Time != 0)
                {
                    var taxDetail = VehicleInsurement.VehicleInsurementDetail.Where(d => d.City.Id == City.Id
                    && d.VehicleType.Id == VehicleModel.Type.Id).FirstOrDefault();
                    if (taxDetail is null)
                    {
                        //throw new UserFriendlyException("Lo sentimos, con los datos ingresados no podemos calcular el precio del seguro.");
                        priceComputed = -1;
                    }
                    else
                    {
                        priceComputed = VehiclePrice * taxDetail.Tax;
                    }
                }
            }
        }

    }
}
