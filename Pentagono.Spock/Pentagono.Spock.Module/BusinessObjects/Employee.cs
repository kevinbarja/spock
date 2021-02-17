using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using Pentagono.Spock.Module.Annotations;
using Pentagono.Spock.Module.DatabaseUpdate;
using Caption = System.ComponentModel.DisplayNameAttribute;

namespace Pentagono.Spock.Module.BusinessObjects
{
    [Caption("Ejecutivos de ventas")]
    [MapInheritance(MapInheritanceType.OwnTable)]
    [Persistent(Schema.SPOCK + nameof(Employee))]
    public class Employee : Person
    {
        public new static string PATH_NAVIGATION = @"Application/NavigationItems/Items/People/Items/Employees";
        public Employee(Session session) : base(session) { }

        string workEmail = string.Empty;
        string workPhone = string.Empty;

        [Caption("Email coorporativo")]
        [Indexed(Unique = true), NonCloneable]
        [VisibleInLookupListView(true)]
        [VisibleInListView(true)]
        [VisibleInDetailView(true)]
        [Size(MEDIUM_STRING_SIZE), Nullable(false), RequiredField]
        public string WorkEmail
        {
            get => workEmail;
            set => SetPropertyValue(ref workEmail, value);
        }

        [Caption("Teléfono coorporativo")]
        [VisibleInLookupListView(true)]
        [VisibleInListView(true)]
        [VisibleInDetailView(true)]
        [Size(MEDIUM_STRING_SIZE), Nullable(false), RequiredField]
        public string WorkPhone
        {
            get => workPhone;
            set => SetPropertyValue(ref workPhone, value);
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