namespace ItemMaster.DTO
{
    public class ItemMasterUpdateRequestDTO
    {
        public int ItemId { get; set; }
        public string? ICode { get; set; }
        public string? IName { get; set; }
        public string? IDesc { get; set; }
        public string? IType { get; set; }
        public int PackingId { get; set; }
        public string? ISize { get; set; }
        public string? MRPPrinted { get; set; }
        public decimal? MOQ { get; set; }
        public int BrandId { get; set; }
        public int IsActive { get; set; }
        public string? ActionUser { get; set; }
    }
}
