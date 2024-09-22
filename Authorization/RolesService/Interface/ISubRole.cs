using RolesService.DTO;

namespace RolesService.Interface
{
    public interface ISubRole
    {
        public Task<SubRolesList> SubRolesMapping(SubRolesDTO subRolesDTO);
    }
}
