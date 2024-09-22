using RolesService.DTO;

namespace RolesService.Interface
{
    public interface IUserGroup
    {
        Task<UserGroupList> ManageUserGroup(UserGroupDTO userGroupDTO);
        Task<UserGroupList> ManageUserGroupPaginated(UserGroupDTO userGroupDTO);
    }
}
