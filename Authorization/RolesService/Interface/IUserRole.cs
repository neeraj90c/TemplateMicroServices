using RolesService.DTO;

namespace RolesService.Interface
{
    public interface IUserRole
    {
        public Task<UserList> UserRoleCRUD(UserRoleDTO userRoleDTO);
        public Task<UserList> PaginatedUserRoleCRUD(UserRoleDTO userRoleDTO);
    }
}
