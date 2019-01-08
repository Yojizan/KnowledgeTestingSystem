using DAL.Entities;
using Microsoft.AspNet.Identity;

namespace DAL.Identity
{
    public class ApplicationRoleManager : RoleManager<ApplicationRole>
    {
        public ApplicationRoleManager(IRoleStore<ApplicationRole, string> store) : base(store) { }
    }
}
