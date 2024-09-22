using Common.DTO;

namespace RolesService.DTO
{
    public class UserRoleDTO : PaginationDTO
    {
        public int ProjectId { get; set; }
        public string RoleName { get; set; }
        public int UserRoleId { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public int IsActive { get; set; }
        public int ActionUser { get; set; }
        public int IsDeleted { get; set; }
    }

    public class UserRoleList
    {
        public IEnumerable<UserRoleDTO> UserRole { get; set; }
    }
}
