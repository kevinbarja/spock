using DevExpress.Data.Filtering;
using DevExpress.Persistent.BaseImpl.PermissionPolicy;
using Pentagono.Spock.Module.BusinessObjects;


namespace Pentagono.Spock.Module.DatabaseUpdate.Seeders
{
    class UserSeeder : Seeder
    {
        public UserSeeder(Updater updater) : base(updater) { }

        public override void Run()
        {
            CreateAdminUser();
            CreateDefaultUser();
        }

        private void CreateAdminUser()
        {
            User userAdmin = FindObject<User>(new BinaryOperator(nameof(PermissionPolicyUser.UserName), User.ADMIN_USERNAME));
            if (userAdmin == null)
            {
                userAdmin = CreateObject<User>();
                userAdmin.UserName = User.ADMIN_USERNAME;
                userAdmin.SetPassword(string.Empty);
                userAdmin.Roles.Add(FindObject<Rol>(new BinaryOperator(nameof(PermissionPolicyRole.Name), Rol.ADMINISTRATORS_ROL_NAME)));
            }
        }

        private void CreateDefaultUser()
        {
            User sampleUser = FindObject<User>(new BinaryOperator(nameof(PermissionPolicyUser.UserName), User.USER_USERNAME));
            if (sampleUser == null)
            {
                sampleUser = CreateObject<User>();
                sampleUser.UserName = User.USER_USERNAME;
                sampleUser.SetPassword("");
                sampleUser.Roles.Add(FindObject<Rol>(new BinaryOperator(nameof(PermissionPolicyRole.Name), Rol.USERS_ROL_NAME)));
            }
        }
    }
}
