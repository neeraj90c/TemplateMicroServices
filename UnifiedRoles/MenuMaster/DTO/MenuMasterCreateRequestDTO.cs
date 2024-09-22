namespace MenuMaster.DTO
{
    public class MenuMasterCreateRequestDTO
    {
        public int ProjectId { get; set; }
        public string? MenuName { get; set; }
        public string? MenuCode { get; set; }
        public string? MenuDesc { get; set; }
        public int DisplayOrder { get; set; }
        public int ParentMenuId { get; set; }
        public int DefaultChildMenuId { get; set; }
        public string? MenuIconUrl { get; set; }
        public string? TemplatePath { get; set; }
        public string? ActionUser { get; set; }
    }
}
