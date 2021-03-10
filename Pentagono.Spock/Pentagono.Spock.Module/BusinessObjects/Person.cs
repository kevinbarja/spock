using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using Pentagono.Spock.Module.Annotations;
using Pentagono.Spock.Module.DatabaseUpdate;
using Caption = System.ComponentModel.DisplayNameAttribute;

namespace Pentagono.Spock.Module.BusinessObjects
{
    [Caption("Personas")]
    [Persistent(Schema.SPOCK + nameof(Person))]
    public class Person : BusinessObject
    {
        public static string PATH_NAVIGATION = @"Application/NavigationItems/Items/People/Items/People";
        
        public Person(Session session) : base(session) { }

        string documentNumber = string.Empty;
        string name = string.Empty;
        //string lastname = string.Empty;
        string phoneNumber = string.Empty;
        string homeAddress = string.Empty;
        string email = string.Empty;

        [Caption("CI")]
        [Indexed(Unique = true), NonCloneable]
        [VisibleInLookupListView(true)]
        [VisibleInListView(true)]
        [VisibleInDetailView(true)]
        [Size(MEDIUM_STRING_SIZE), Nullable(false), RequiredField]
        public string DocumentNumber
        {
            get => documentNumber;
            set => SetPropertyValue(ref documentNumber, value);
        }

        [Caption("Nombre completo")]
        [VisibleInLookupListView(true)]
        [VisibleInListView(true)]
        [VisibleInDetailView(true)]
        [Size(MEDIUM_STRING_SIZE), Nullable(false), RequiredField]
        public string Name
        {
            get => name;
            set => SetPropertyValue(ref name, value);
        }

        /*
        [Caption("Apellidos")]
        [VisibleInLookupListView(true)]
        [VisibleInListView(true)]
        [VisibleInDetailView(true)]
        [Size(MEDIUM_STRING_SIZE), Nullable(false), RequiredField]
        public string Lastname
        {
            get => lastname;
            set => SetPropertyValue(ref lastname, value);
        }
        */

        [Caption("Teléfono personal")]
        [VisibleInLookupListView(true)]
        [VisibleInListView(true)]
        [VisibleInDetailView(true)]
        [Size(MEDIUM_STRING_SIZE), Nullable(false), RequiredField]
        public string PhoneNumber
        {
            get => phoneNumber;
            set => SetPropertyValue(ref phoneNumber, value);
        }

        [Caption("Email personal")]
        [Indexed(Unique = true), NonCloneable]
        [VisibleInLookupListView(true)]
        [VisibleInListView(true)]
        [VisibleInDetailView(true)]
        [Size(MEDIUM_STRING_SIZE), Nullable(false), RequiredField]
        public string Email
        {
            get => email;
            set => SetPropertyValue(ref email, value);
        }

        [Caption("Domicilio")]
        [VisibleInLookupListView(true)]
        [VisibleInListView(true)]
        [VisibleInDetailView(true)]
        [Size(MEDIUM_STRING_SIZE), Nullable(false), RequiredField]
        public string HomeAddress
        {
            get => homeAddress;
            set => SetPropertyValue(ref homeAddress, value);
        }
    }
}