using Abp.Authorization;
using Store.System.Authorization.Roles;
using Store.System.Authorization.Users;

namespace Store.System.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
