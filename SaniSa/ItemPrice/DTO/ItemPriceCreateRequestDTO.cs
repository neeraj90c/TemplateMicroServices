namespace ItemPrice.DTO
{
    public class ItemPriceCreateRequestDTO
    {
        public int ItemId { get; set; }
        public decimal MRP { get; set; }
        public decimal IP1 { get; set; }
        public decimal IP2 { get; set; }
        public decimal IP3 { get; set; }
        public decimal CP { get; set; }
        public string? ActionUser { get; set; }

    }
}
