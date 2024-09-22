namespace CategoryMaster.DTO
{
    public class CategoryMasterUpdateRequestDTO
    {
        public int CategoryId { get; set; }
        public string CCode { get; set; }
        public string CName { get; set; }
        public string CDesc { get; set; }
        public int CompanyId { get; set; }
        public int IsActive { get; set; } = 1;
        public string ActionUser { get; set; }

    }
}
