using Common.DTO;

namespace ItemPrice.DTO
{
    public class ItemPriceDTO : PaginationDTO
    {
        public int PriceId { get; set; }
        public int ItemId { get; set; }
        public decimal MRP { get; set; }
        public decimal IP1 { get; set; }
        public decimal IP2 { get; set; }
        public decimal IP3 { get; set; }
        public decimal CP { get; set; }
        public int IsActive { get; set; }
        public int IsDeleted { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
    public class ItemPriceList
    {
        public IEnumerable<ItemPriceDTO> Items { get; set; }
    }
}
