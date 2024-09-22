using Common.DTO;

namespace ProductCombo.DTO
{
    public class ProductComboDTO : PaginationDTO
    {
        public int ComboId { get; set; }
        public string? CCode { get; set; }
        public string? CName { get; set; }
        public string? CDescription { get; set; }
        public string? CreationType { get; set; }
        public int IsActive { get; set; }
        public int IsDeleted { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
    public class ProductComboList
    {
        public IEnumerable<ProductComboDTO> Items { get; set; }
    }
}
