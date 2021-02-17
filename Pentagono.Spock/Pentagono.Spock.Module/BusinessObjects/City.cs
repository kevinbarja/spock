using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using Pentagono.Spock.Module.Annotations;
using Pentagono.Spock.Module.DatabaseUpdate;
using Caption = System.ComponentModel.DisplayNameAttribute;

namespace Pentagono.Spock.Module.BusinessObjects
{
    [Caption("Ciudades")]
    [Persistent(Schema.SPOCK + nameof(City))]
    public class City : BusinessObject
    {
        public static string PATH_NAVIGATION = @"Application/NavigationItems/Items/Params/Items/Cities";
        public static string SANTA_CRUZ = "Santa Cruz";
        public City(Session session) : base(session) { }

        string code = string.Empty;
        string name = string.Empty;

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