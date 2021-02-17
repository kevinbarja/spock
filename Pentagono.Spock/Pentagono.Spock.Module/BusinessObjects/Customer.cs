using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using Pentagono.Spock.Module.Annotations;
using Pentagono.Spock.Module.DatabaseUpdate;
using Caption = System.ComponentModel.DisplayNameAttribute;

namespace Pentagono.Spock.Module.BusinessObjects
{
    [Caption("Clientes")]
    [MapInheritance(MapInheritanceType.OwnTable)]
    [Persistent(Schema.SPOCK + nameof(Customer))]
    public class Customer : Person
    {
        public new static string PATH_NAVIGATION = @"Application/NavigationItems/Items/People/Items/Customers";
        public Customer(Session session) : base(session) { }

        string notes = string.Empty;

        [Caption("Notas")]
        [NonCloneable]
        [VisibleInLookupListView(true)]
        [VisibleInListView(true)]
        [VisibleInDetailView(true)]
        [Size(LARGE_STRING_SIZE), Nullable(false), RequiredField]
        public string Notes
        {
            get => notes;
            set => SetPropertyValue(ref notes, value);
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