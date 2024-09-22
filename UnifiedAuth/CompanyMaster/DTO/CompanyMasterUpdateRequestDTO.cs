namespace CompanyMaster.DTO
{
    public class CompanyMasterUpdateRequestDTO
    {
        public int CompanyId { get; set; }
        public string? CName { get; set; }
        public string? CCode { get; set; }
        public string? CDesc { get; set; }
        public string? CAddress { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Website { get; set; }
        public string? Category { get; set; }
        public string? SubCategory { get; set; }
        public string? ContactPerson { get; set; }
        public int IsActive { get; set; }
        public string? CType { get; set; }
        public string? ActionUser { get; set; }
    }
}
