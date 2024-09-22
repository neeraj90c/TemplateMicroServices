namespace ItemPrice.DTO
{
    public class ItemPriceUpdateRequestDTO
    {
        public int PriceId { get; set; }
        public int ItemId { get; set; }
        public decimal MRP { get; set; }
        public decimal? IP1 { get; set; }
        public decimal? IP2 { get; set; }
        public decimal? IP3 { get; set; }
        public decimal CP { get; set; }
        public int IsActive { get; set; }
        public string? ActionUser { get; set; }
    }
}
