namespace RolesService.DTO
{
    public class SubRolesDTO
    {
        public int MenuId { get; set; }
        public int ProjectId { get; set; }
        public string MenuName { get; set; }
        public string MenuCode { get; set; }
        public string MenuDesc { get; set; }
        public int ParentMenuId { get; set; }
        public int RoleId { get; set; }
        public int DisplayOrder { get; set; }
        public int SubRoleId { get; set; }
        public Boolean HasAccess { get; set; }
        public int ActionUser { get; set; }
        public int IsActive { get; set; }
        public int IsDeleted { get; set; }

    }

    public class SubRolesList
    {
        public IEnumerable<SubRolesDTO> SubRoles { get; set; }
    }
}
