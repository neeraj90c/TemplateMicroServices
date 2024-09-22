namespace BrandMaster.DTO
{
    public class BrandMasterUpdateRequestDTO
    {
        public int BrandId { get; set; }
        public string? BCode { get; set; }
        public string? BName { get; set; }
        public string? BDesc { get; set; }
        public int CompanyId { get; set; }
        public int IsActive { get; set; }
        public string? ActionUser { get; set; }
    }
}
