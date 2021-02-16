﻿using DevExpress.Data.Filtering;
using DevExpress.ExpressApp.Security;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.BaseImpl.PermissionPolicy;
using Pentagono.Spock.Module.BusinessObjects;

namespace Pentagono.Spock.Module.DatabaseUpdate.Seeders
{
    class RolSeeder : Seeder
    {
        public RolSeeder(Updater updater) : base(updater) { }

        public override void Run()
        {
            CreateAdministratorsRol();
            CreateUsersRol();
        }

        private void CreateAdministratorsRol()
        {
            // If a role with the Administrators name doesn't exist in the database, create this role
            Rol adminRole = FindObject<Rol>(new BinaryOperator(nameof(PermissionPolicyRole.Name), Rol.ADMINISTRATORS_ROL_NAME));
            if (adminRole is null)
            {
                adminRole = CreateObject<Rol>();
                adminRole.Name = Rol.ADMINISTRATORS_ROL_NAME;
                adminRole.IsAdministrative = true;
            }
        }

        private void CreateUsersRol()
        {
            Rol usersRole = FindObject<Rol>(new BinaryOperator(nameof(PermissionPolicyRole.Name), Rol.USERS_ROL_NAME));
            if (usersRole == null)
            {
                usersRole = CreateObject<Rol>();
                usersRole.Name = Rol.USERS_ROL_NAME;

                usersRole.AddObjectPermission<PermissionPolicyUser>(SecurityOperations.Read, "[Oid] = CurrentUserId()", SecurityPermissionState.Allow);
                usersRole.AddNavigationPermission(@"Application/NavigationItems/Items/Default/Items/MyDetails", SecurityPermissionState.Allow);
                usersRole.AddMemberPermission<PermissionPolicyUser>(SecurityOperations.Write, nameof(PermissionPolicyUser.ChangePasswordOnFirstLogon), "[Oid] = CurrentUserId()", SecurityPermissionState.Allow);
                usersRole.AddMemberPermission<PermissionPolicyUser>(SecurityOperations.Write, "StoredPassword", "[Oid] = CurrentUserId()", SecurityPermissionState.Allow);
                usersRole.AddTypePermissionsRecursively<PermissionPolicyRole>(SecurityOperations.Read, SecurityPermissionState.Deny);
                usersRole.AddTypePermissionsRecursively<ModelDifference>(SecurityOperations.ReadWriteAccess, SecurityPermissionState.Allow);
                usersRole.AddTypePermissionsRecursively<ModelDifferenceAspect>(SecurityOperations.ReadWriteAccess, SecurityPermissionState.Allow);
                usersRole.AddTypePermissionsRecursively<ModelDifference>(SecurityOperations.Create, SecurityPermissionState.Allow);
                usersRole.AddTypePermissionsRecursively<ModelDifferenceAspect>(SecurityOperations.Create, SecurityPermissionState.Allow);
            }
        }
    }
}