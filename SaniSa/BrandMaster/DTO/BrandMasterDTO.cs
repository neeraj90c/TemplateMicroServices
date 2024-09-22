using Common.DTO;

namespace BrandMaster.DTO
{
    public class BrandMasterDTO : PaginationDTO
    {
        public int BrandId { get; set; }
        public string BCode { get; set; }
        public string BName { get; set; }
        public string BDesc { get; set; }
        public int CompanyId { get; set; }
        public int IsActive { get; set; }
        public int IsDeleted { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
    public class BrandMasterList
    {
        public IEnumerable<BrandMasterDTO> Items { get; set; }
    }
}
