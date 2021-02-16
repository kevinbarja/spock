using DevExpress.Persistent.BaseImpl.PermissionPolicy;
using DevExpress.Xpo;
using Pentagono.Spock.Module.DatabaseUpdate;
using System.ComponentModel;
using Caption = System.ComponentModel.DisplayNameAttribute;

namespace Pentagono.Spock.Module.BusinessObjects
{
    [Caption("Roles")]
    [Persistent(Schema.SPOCK + nameof(Rol))]
    public class Rol : PermissionPolicyRole
    {
        public static string ADMINISTRATORS_ROL_NAME = "Administradores";
        public static string USERS_ROL_NAME = "Usuarios";

        public Rol(Session session) : base(session) { }

        [Caption("Nombre")]
        public new string Name
        {
            get => base.Name;
            set => base.Name = value;
        }

        [Caption("Es administrativo")]
        public new bool IsAdministrative
        {
            get => base.IsAdministrative;
            set => base.IsAdministrative = value;
        }

        [Caption()]
        [Browsable(false)]
        public new bool CanEditModel
        {
            get => base.CanEditModel;
            set => base.CanEditModel = value;
        }
    }
}
