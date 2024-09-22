namespace BrandMaster.DTO
{
    public class BrandMasterCreateRequestDTO
    {
        public string? BCode { get; set; }
        public string? BName { get; set; }
        public string? BDesc { get; set; }
        public string? ActionUser { get; set; }
        public int CompanyId { get; set; }

    }
}
