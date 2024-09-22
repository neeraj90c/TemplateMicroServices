using Common.DTO;
using RolesService.DTO;

namespace RolesService.Interface
{
    public interface IRole
    {
        public Task<RolesList> ManageRoles(RolesDTO rolesDTO);
        Task<DropDownList> GetRolesDictionary();
    }
}
