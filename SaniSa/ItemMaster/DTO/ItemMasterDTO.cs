using Common.DTO;

namespace ItemMaster.DTO
{
    public class ItemMasterDTO : PaginationDTO
    {
        public int ItemId { get; set; }
        public string? ICode { get; set; }
        public string? IName { get; set; }
        public string? IDesc { get; set; }
        public string? IType { get; set; }
        public int PackingId { get; set; }
        public string? ISize { get; set; }
        public string? MRPPrinted { get; set; }
        public decimal MOQ { get; set; }
        public int BrandId { get; set; }
        public int IsActive { get; set; }
        public int IsDeleted { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string? ImagePath {  get; set; }
        public decimal MRP {  get; set; }
        public string? BName { get; set; }
        public int? DetailId { get; set; }
        public string? KName { get; set; }

    }
    public class ItemMasterList
    {
        public IEnumerable<ItemMasterDTO> Items { get; set; }
    }
}
