using Common.DTO;

namespace RolesService.DTO
{
    public class RolesDTO : PaginationDTO
    {
        public int RoleId { get; set; }
        public int ProjectId { get; set; }
        public string? RoleName { get; set; }
        public string? RoleCode { get; set; }
        public string? RoleDesc { get; set; }
        public int IsActive { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public int IsDeleted { get; set; }
        public int ActionUser { get; set; }

    }
    public class RolesList
    {
        public IEnumerable<RolesDTO> Roles { get; set; }
    }
}
