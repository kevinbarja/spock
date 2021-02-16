using DevExpress.Persistent.BaseImpl.PermissionPolicy;
using DevExpress.Xpo;
using Pentagono.Spock.Module.DatabaseUpdate;
using System.ComponentModel;
using Caption = System.ComponentModel.DisplayNameAttribute;
using System.Linq;

namespace Pentagono.Spock.Module.BusinessObjects
{
    [Caption("Usuarios")]
    [Persistent(Schema.SPOCK + nameof(User))]
    public class User : PermissionPolicyUser
    {
        public static string ADMIN_USERNAME = "Admin";
        public static string USER_USERNAME = "Usuario";

        public User(Session session) : base(session) { }

        [Browsable(false), NonPersistent]
        public bool IsAdministrative { get { return Roles.Where(rol => rol.IsAdministrative).Any(); } }
    }
}
