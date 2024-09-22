namespace MenuMaster.DTO
{
    public class MenuMasterDTO
    {
        public int MenuId { get; set; }
        public int ProjectId { get; set; }
        public string? MenuName { get; set; }
        public string? MenuCode { get; set; }
        public string? MenuDesc { get; set; }
        public int DisplayOrder { get; set; }
        public int ParentMenuId { get; set; }
        public int DefaultChildMenuId { get; set; }
        public string? MenuIconUrl { get; set; }
        public string? TemplatePath { get; set; }
        public int IsActive { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public int IsDeleted { get; set; }
    }
    public class MenuMasterList
    {
        public IEnumerable<MenuMasterDTO> Items { get; set; }
    }
}
