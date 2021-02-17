using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using Pentagono.Spock.Module.Annotations;
using Pentagono.Spock.Module.DatabaseUpdate;
using System;
using Caption = System.ComponentModel.DisplayNameAttribute;

namespace Pentagono.Spock.Module.BusinessObjects
{
    [Caption("Polizas vehiculares")]
    [Persistent(Schema.SPOCK + nameof(VehiclePolicy))]
    public class VehiclePolicy : BusinessObject
    {
        public static string PATH_NAVIGATION = @"Application/NavigationItems/Items/Policies/Items/VehiclePolicies";

        public VehiclePolicy(Session session) : base(session) { }

        string code = string.Empty;
        VehicleQuotation vehicleQuotation;
        DateTime startDate;
        DateTime endDate;

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

        [Caption("Cotización")]
        [Persistent("VehicleQuotation_VehicleQuotation")]
        [RequiredField]
        public VehicleQuotation VehicleQuotation
        {
            get => vehicleQuotation;
            set => SetPropertyValue(ref vehicleQuotation, value);
        }

        [Caption("Fecha de inicio")]
        [DbType("date"), RequiredField]
        public DateTime StartDate
        {
            get => startDate;
            set => SetPropertyValue(ref startDate, value);
        }

        [Caption("Fecha de finalización")]
        [DbType("date"), RequiredField]
        public DateTime EndDate
        {
            get => endDate;
            set => SetPropertyValue(ref endDate, value);
        }
    }
}