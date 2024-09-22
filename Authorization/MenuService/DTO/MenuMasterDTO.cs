namespace MenuService.DTO
{
    public class MenuMasterDTO
    {
        public int UserId { get; set; }
        public int ProjectId { get; set; }
        public int RoleId { get; set; }
        public int MenuId { get; set; }
        public int ParentMenuId { get; set; }
        public int SubRoleId { get; set; }
        public string SubRoleName { get; set; }
        public string SubRoleCode { get; set; }
        public string SubRoleDesc { get; set; }
        public int DisplayOrder { get; set; }
        public int DefaultChildMenuId { get; set; }
        public string MenuIconUrl { get; set; }
        public string TemplatePath { get; set; }
        public int IsParent { get; set; }
        public int ChildrenCount { get; set; }
        public int ChildIsParent { get; set; }
    }
    public class MenuMasterList
    {
        public IEnumerable<MenuMasterDTO> Items { get; set; }
    }
}
